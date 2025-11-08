# XUnit3Helper.StartupModule

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/src/XUnit3Helper.StartupModule/README.md)
[![ru](https://img.shields.io/badge/lang-ru-green.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/src/XUnit3Helper.StartupModule/README.ru.md)

This package is required by the [XUnit3Helper.Integration](https://www.nuget.org/packages/XUnit3Helper.Integration/0.0.4-alpha).
It contains an abstract startup module which you should use as a base for implementing your Web API.

Example — concise constructor syntax:
```csharp
    public sealed class Startup(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager)
        : BaseStartupModule(environment, configurationManager)
    {
    }
```

Or using an explicit constructor that calls the base:
```csharp
    public sealed class Startup
        : BaseStartupModule
    {
        public Startup(
            IWebHostEnvironment environment,
            ConfigurationManager configurationManager)
            : base(environment, configurationManager)
        {
        }
    }
```

You must also implement these methods:

- ConfigureConfigurationInternal
```csharp
    protected abstract IConfiguration ConfigureConfigurationInternal(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager);
```

Example:
```csharp
    protected override IConfiguration ConfigureConfigurationInternal(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager)
    {
        return configurationManager
            //Set the application content root path
            .SetBasePath(environment.ContentRootPath)
             //Add appsettings file
            .AddJsonFile("appsettings.json")
             //Add environment-specific appsettings file (optional)
            .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
             //Add environment variables
            .AddEnvironmentVariables()
            .Build();
    }
```

- ConfigureServices
```csharp
    public override IServiceCollection ConfigureServices(IServiceCollection services);
```

Example:
```csharp
    public override IServiceCollection ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
```

- Configure
```csharp
    public override IApplicationBuilder Configure(IApplicationBuilder app);
```

Example:
```csharp
    public override IApplicationBuilder Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseCors(policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseAuthorization();

        app.UseEndpoints(configure => configure.MapControllers());

        return app;
    }
```

As a result, your `Program.cs` will look like this:
```csharp
    var builder = WebApplication.CreateBuilder(args);

    var startup = new Startup(builder.Environment, builder.Configuration);

    startup.ConfigureServices(builder.Services);

    var applicationBuilder = builder.Build();
    startup.Configure(applicationBuilder);

    await applicationBuilder.RunAsync();
```
