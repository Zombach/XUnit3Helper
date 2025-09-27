
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
using XUnit3Helper.Common.Extensions;
using XUnit3Helper.StartupModule;

namespace XUnit3Helper.Integration;

public abstract class BaseWebApplicationFactory
{
    protected static readonly ReloadableLogger Logger = new LoggerConfiguration()
        .WriteTo.Console(formatProvider: CultureInfo.CurrentCulture)
        .CreateBootstrapLogger();

    protected static readonly ConcurrentDictionary<Guid, Lazy<WebApplication>> LazyServers = new();
    protected static readonly ConcurrentDictionary<Guid, ushort> ServerPorts = new();

    protected abstract Guid ServerKey { get; }
    protected abstract Assembly ControllersAssembly { get; }
    protected virtual string Environment => "testing";
}

public abstract class BaseWebApplicationFactory<TStartupModule>
    : BaseWebApplicationFactory, IAsyncLifetime
    where TStartupModule : class, IStartupModule
{
    public Lazy<WebApplication> LazyServer => LazyServers
        .GetValueOrDefault(ServerKey) ?? throw new ArgumentException(nameof(LazyServer));

    protected virtual IEnumerable<Type> ServiceTypeForMock { get; } = new List<Type>();

    public ushort ServerPort => GetServerPort();

    public ValueTask InitializeAsync()
    {
        LazyServers.GetOrAdd(
            ServerKey,
            _ => new Lazy<WebApplication>(CreateTestServer, LazyThreadSafetyMode.ExecutionAndPublication));

        return ValueTask.CompletedTask;
    }

    protected virtual WebApplication CreateTestServer()
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

            var startup = CreateStartupModule(webApplicationBuilder.Environment)!;

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

    private static IStartupModule? CreateStartupModule(IWebHostEnvironment webHostEnvironment)
    {
        try
        {
            var startupType = typeof(TStartupModule);
            var constructorInfo = startupType.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public,
                null,
                CallingConventions.HasThis,
                [typeof(IWebHostEnvironment)],
                null);

            return constructorInfo?.Invoke([webHostEnvironment]) as TStartupModule;
        }
        catch (Exception exception)
        {
            Logger.Error(exception, "{@Message}", exception.Message);
            return null;
        }
    }

    private static ushort GetRandomUnusedPort()
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
            catch (SocketException socketException)
            {
            }
            finally
            {
                portGrabber?.Stop();
            }

        } while (true);
    }

    private ushort GetServerPort()
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
