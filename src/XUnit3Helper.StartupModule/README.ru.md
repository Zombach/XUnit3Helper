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

Так же необходимо переопределить данный метод "ConfigureConfigurationInternal"

```csharp
    protected abstract IConfiguration ConfigureConfigurationInternal(
        IWebHostEnvironment environment,
        ConfigurationManager configurationManager);
```

Например

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
