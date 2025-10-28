using System.Collections.Concurrent;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Extensions.Hosting;
using Xunit;
using XUnit3Helper.Extensions;
using XUnit3Helper.StartupModule;

namespace XUnit3Helper.Integration;

public abstract class BaseWebApplicationFactory
    : IAsyncLifetime
{
    protected static readonly ReloadableLogger Logger = new LoggerConfiguration()
        .WriteTo.Console(formatProvider: CultureInfo.CurrentCulture)
        .CreateBootstrapLogger();

    protected static readonly ConcurrentDictionary<Guid, Lazy<WebApplication>> LazyServers = new();
    protected static readonly ConcurrentDictionary<Guid, ushort> ServerPorts = new();

    protected abstract Guid ServerKey { get; }
    protected abstract Assembly ControllersAssembly { get; }
    protected virtual string Environment => "testing";
    protected virtual IEnumerable<Type> ServiceTypeForMock { get; } = new List<Type>();

    protected abstract WebApplication CreateTestServer();

    public ushort ServerPort => GetServerPort();

    public ValueTask InitializeAsync()
    {
        LazyServers.GetOrAdd(
            ServerKey,
            _ => new Lazy<WebApplication>(CreateTestServer, LazyThreadSafetyMode.ExecutionAndPublication));

        return ValueTask.CompletedTask;
    }

    public virtual async ValueTask DisposeAsync()
    {
        if (LazyServers.TryRemove(ServerKey, out var server)
            && server.IsValueCreated)
        {
            await server.Value.DisposeAsync();
        }

        ServerPorts.TryRemove(ServerKey, out _);

        GC.SuppressFinalize(this);
    }

    protected virtual ushort GetRandomUnusedPort()
    {
        var portGrabber = default(TcpListener);

        do
        {
            try
            {
                portGrabber = new TcpListener(IPAddress.Loopback, 0);
                portGrabber.Start();

                var ipEndPoint = (IPEndPoint)portGrabber.LocalEndpoint;
                return (ushort)ipEndPoint.Port;
            }
            catch (SocketException) { /* ignore */}
            finally
            {
                portGrabber?.Stop();
            }

        } while (true);
    }

    protected virtual ushort GetServerPort()
    {
        if (!ServerPorts.TryGetValue(ServerKey, out var port))
        {
            if (!LazyServers.TryGetValue(ServerKey, out var lazyServer))
            {
                throw new ArgumentException(nameof(ServerPort));
            }

            _ = lazyServer.Value;
        }

        return port;
    }
}

public abstract class BaseWebApplicationFactory<TStartupModule>
    : BaseWebApplicationFactory
    where TStartupModule : class, IStartupModule
{
    public Lazy<WebApplication> LazyServer => LazyServers
        .GetValueOrDefault(ServerKey) ?? throw new ArgumentException(nameof(LazyServer));

    protected override WebApplication CreateTestServer()
    {
        try
        {
            var webApplicationOptions = new WebApplicationOptions
            {
                EnvironmentName = Environment,
                ContentRootPath = string.Empty
            };

            var webApplicationBuilder = WebApplication.CreateBuilder(webApplicationOptions);

            var webHost = webApplicationBuilder.WebHost
                .ConfigureKestrel(options =>
                {
                    var port = GetRandomUnusedPort();
                    ServerPorts.AddOrUpdate(
                        ServerKey,
                        port,
                        (_, __) => port);

                    options.Listen(
                        IPAddress.Loopback,
                        port,
                        listenOptions => listenOptions
                            .Protocols = HttpProtocols.Http1AndHttp2);
                })
                .ConfigureLogging((context, loggingBuilder) =>
                {
                    Log.CloseAndFlush();
                    loggingBuilder.AddSerilog(Logger);
                });

            var startup = CreateStartupModule(
                webApplicationBuilder.Environment,
                webApplicationBuilder.Configuration)!;

            var configuration = ConfigureAppConfiguration(
                    webApplicationBuilder.Configuration,
                    webApplicationBuilder.Environment)
                .Build();

            var services = webApplicationBuilder.Services;
            startup.ConfigureServices(services);

            services.AddMocks(ServiceTypeForMock);

            services.AddControllers()
                .AddApplicationPart(ControllersAssembly);

            var webApplication = webApplicationBuilder.Build();

            startup.Configure(webApplication);
            webApplication.Start();

            return webApplication;
        }
        catch (Exception exception)
        {
            Logger.Error(exception, "{@Message}", exception.Message);
            throw;
        }
    }

    protected virtual IConfigurationBuilder ConfigureAppConfiguration(
        IConfigurationBuilder configurationBuilder,
        IWebHostEnvironment webHostEnvironment)
    {
        configurationBuilder.AddJsonFile("appsettings.json", false)
            .AddJsonFile($"appsettings.{webHostEnvironment.EnvironmentName}.json", true);

        return configurationBuilder;
    }

    private static IStartupModule CreateStartupModule(
        IWebHostEnvironment webHostEnvironment,
        ConfigurationManager configurationManager)
    {
        try
        {
            var startupType = typeof(TStartupModule);
            var constructorInfo = startupType.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null,
                CallingConventions.HasThis,
                [typeof(IWebHostEnvironment), typeof(ConfigurationManager)],
                null);

            var startupModule = constructorInfo?.Invoke([webHostEnvironment, configurationManager]) as TStartupModule;
            ArgumentNullException.ThrowIfNull(startupModule);

            return startupModule;
        }
        catch (Exception exception)
        {
            Logger.Error(exception, "{@Message}", exception.Message);
            throw;
        }
    }
}
