using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace XUnit3Helper.StartupModule.Tests;

public sealed class BaseStartupModuleTests
{
    // Заглушка IWebHostEnvironment для конструктора BaseStartupModule
    private sealed class TestWebHostEnvironment
        : IWebHostEnvironment
    {
        public string ApplicationName { get; set; } = "TestApp";
        public IFileProvider? ContentRootFileProvider { get; set; }
        public string ContentRootPath { get; set; } = Directory.GetCurrentDirectory();
        public string EnvironmentName { get; set; } = "Test";
        public IFileProvider? WebRootFileProvider { get; set; }
        public string WebRootPath { get; set; } = "wwwroot";
    }

    // Тестовая конкретная реализация BaseStartupModule
    private sealed class TestableBaseStartupModule(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager)
        : BaseStartupModule(environment, configurationManager)
    {
        public bool ConfigureConfigurationCalled { get; private set; }
        public IWebHostEnvironment? ReceivedEnvironment { get; private set; }
        public ConfigurationManager? ReceivedConfigurationManager { get; private set; }

        protected override IConfiguration ConfigureConfigurationInternal(
            IWebHostEnvironment environment,
            ConfigurationManager configurationManager)
        {
            ConfigureConfigurationCalled = true;
            ReceivedEnvironment = environment;
            ReceivedConfigurationManager = configurationManager;

            return configurationManager
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("assets/appsettings.json")
                .AddJsonFile($"assets/appsettings.{environment.EnvironmentName}.json", true)
                .Build();
        }

        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton("TestableObject");
            return services;
        }

        public override IApplicationBuilder Configure(IApplicationBuilder app)
        {
            return app;
        }
    }

    [Fact]
    public void BaseStartupModule_Constructor_Calls_ConfigureConfigurationInternal_And_Sets_Configuration()
    {
        // Arrange
        var inMemory = new Dictionary<string, string?>
        {
            ["baseKey"] = "baseValue",
            ["testKey"] = "testValue",
        };
        var configurationBuilder = new ConfigurationBuilder().AddInMemoryCollection(inMemory);
        var expected = configurationBuilder.Build();
        var env = new TestWebHostEnvironment();
        var configurationManager = new ConfigurationManager();

        // Act
        var module = new TestableBaseStartupModule(env, configurationManager);

        // Assert
        Assert.True(module.ConfigureConfigurationCalled, "ConfigureConfigurationInternal должен быть вызван в конструкторе");
        Assert.Same(env, module.ReceivedEnvironment);
        Assert.Same(configurationManager, module.ReceivedConfigurationManager);
        Assert.EquivalentWithExclusions(expected, module.Configuration, "Providers");
    }

    [Fact]
    public void BaseStartupModule_ConfigureServices_Adds_Expected_Service_And_Configure_Returns_App()
    {
        // Arrange
        var env = new TestWebHostEnvironment();
        var configurationManager = new ConfigurationManager();

        var module = new TestableBaseStartupModule(env, configurationManager);

        var services = new ServiceCollection();
        var sp = services.BuildServiceProvider();
        var app = new ApplicationBuilder(sp);

        // Act
        var returnedServices = module.ConfigureServices(services);
        var returnedApp = module.Configure(app);

        // Assert
        Assert.Same(services, returnedServices);
        Assert.Same(app, returnedApp);

        var provider = returnedServices.BuildServiceProvider();
        var marker = provider.GetService<string>();
        Assert.Equal("TestableObject", marker);
    }
}
