# XUnit3Helper.StartupModule

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/src/XUnit3Helper.StartupModule/README.md)
[![ru](https://img.shields.io/badge/lang-ru-green.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/src/XUnit3Helper.StartupModule/README.ru.md)

Данный пакет необходим для [XUnit3Helper.Integration](https://www.nuget.org/packages/XUnit3Helper.Integration/0.0.3-alpha).
Содержит абстрактный модуль на базе которого необходимо реализовать ваше WebApi

```csharp
    public sealed class Startup(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager)
        : BaseStartupModule(environment, configurationManager)
    {
    }
```

или

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

Так же необходимо реализовать данные методы:

  - ConfigureConfigurationInternal
```csharp
    protected abstract IConfiguration ConfigureConfigurationInternal(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager);
```

Например:
```csharp
    protected override IConfiguration ConfigureConfigurationInternal(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager)
    {
        return configurationManager
            //Устанавливаем путь приложения
            .SetBasePath(environment.ContentRootPath)
             //Добавляем файл appsettings.json
            .AddJsonFile("appsettings.json")
             //Добавляем файл appsettings.Environment.json, зависящий от environment.EnvironmentName
            .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
             //Добавляем переменные окружения
            .AddEnvironmentVariables()
            .Build();
    }
```

  - ConfigureServices
```csharp
    public override IServiceCollection ConfigureServices(IServiceCollection services);
```

Например:
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

Например:
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

В результате ваш Program.cs будет выглядеть следующим образом:
```csharp
    var builder = WebApplication.CreateBuilder(args);

    var startup = new Startup(builder.Environment, builder.Configuration);

    startup.ConfigureServices(builder.Services);

    var applicationBuilder = builder.Build();
    startup.Configure(applicationBuilder);

    await applicationBuilder.RunAsync();
```
