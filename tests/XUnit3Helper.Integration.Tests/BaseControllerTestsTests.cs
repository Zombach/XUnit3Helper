using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XUnit3Helper.Integration;
using XUnit3Helper.StartupModule;

namespace XUnit3Helper.Integrations.Tests;

public sealed class BaseControllerTestsTests
{
    private sealed class MinimalStartup(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager)
        : BaseStartupModule(environment, configurationManager)
    {
        protected override IConfiguration ConfigureConfigurationInternal(
            IWebHostEnvironment environment,
            ConfigurationManager configurationManager)
        {
            // keep default configuration
            return configurationManager
                .SetBasePath(environment.ContentRootPath)
                .Build();
        }

        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            // Register IHttpClientFactory so CreateClient can resolve it
            services.AddHttpClient();
            services.AddControllers();
            return services;
        }

        public override IApplicationBuilder Configure(IApplicationBuilder application)
        {
            application.UseRouting();
            application.UseEndpoints(_ => { });
            return application;
        }
    }

    private sealed class TestFactory
        : BaseWebApplicationFactory<MinimalStartup>
    {
        protected override Guid ServerKey { get; } = Guid.NewGuid();
        protected override Assembly ControllersAssembly { get; } = typeof(MinimalStartup).Assembly;

        protected override IConfigurationBuilder ConfigureAppConfiguration(
            IConfigurationBuilder configurationBuilder,
            IWebHostEnvironment webHostEnvironment)
        {
            return configurationBuilder;
        }
    }

    private sealed class ConcreteControllerTests(TestFactory applicationFactory)
        : BaseControllerTests<MinimalStartup, TestFactory>(applicationFactory)
    {
        public HttpClient CreateClientPublic() => CreateClient();
    }

    [Fact]
    public async Task CreateClient_Returns_HttpClient_With_ServerPort_BaseAddress()
    {
        var factory = new TestFactory();
        try
        {
            await factory.InitializeAsync();

            var sut = new ConcreteControllerTests(factory);
            using var client = sut.CreateClientPublic();

            Assert.NotNull(client.BaseAddress);
            Assert.Equal("localhost", client.BaseAddress.Host, ignoreCase: true);
            Assert.Equal(factory.ServerPort, (ushort)client.BaseAddress.Port);
        }
        finally
        {
            await factory.DisposeAsync();
        }
    }
}
