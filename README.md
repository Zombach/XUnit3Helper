[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/README.md)
[![ru](https://img.shields.io/badge/lang-ru-green.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/README.ru.md)

# XUnit3Helper

A utility library for convenient work with `xUnit v3`.
Designed to speed up writing parameterized tests and to simplify preparing mocks in DI containers.

Key features
- Attribute `JsonFileDataAttribute` — load data for `Theory` from a JSON file (multiple formats, sections).
- Attribute `CustomAutoDataAttribute` — ready-made configuration for `AutoFixture` + `AutoMoq` (including `ConfigureMembers` and recursion behavior).
- Extension `MockExtension.AddMocks` — bulk registration of `Moq` mocks into `IServiceCollection`.
- Helper generator `GenerateTestDataExtension` and model `TestData` — support for deserializing JSON into parameter sets up to 15 arguments.
- Supported targets: `net8.0`, `net9.0`, `net10.0`.

## Usage
1) `JsonFileDataAttribute`
- Constructor: `JsonFileDataAttribute(string filePath, bool simpleTypeJson = false, string? sectionKey = null)`
- Behavior:
  - Checks that the file exists.
  - If `sectionKey` is specified, extracts the corresponding JSON section (top-level key).
  - Supports two JSON formats:
    - "Complex" — an array of objects with fields `P1`, `P2`, ... (matches the `TestData` models).
    - "Simple" (`simpleTypeJson = true`) — an array of arrays or an array of strings/numbers, where each element of an inner array corresponds to a test parameter.
  - Limitation: up to 15 parameters (the test-case generation logic is implemented for 1..15 parameters).
- Examples:
Complex data format (recommended):
```json
[
    {
        "P1": 1,
        "P2": "a",
        "P3": true
    },
    {
        "P1": 2,
        "P2": "b",
        "P3": false
    }
]
```
Simple types format (`simpleTypeJson = true`):
```json
[
    [1, "a", true],
    [2, "b", false]
]
```

Usage in tests:
```csharp
    [Theory, JsonFileData("testdata.json")]
    public void MyTest(int a, string b, bool flag)
    {
        // ...
    }
```

```csharp
    [Theory, JsonFileData("simple.json", simpleTypeJson: true)]
    public void SimpleTest(int a, string b)
    {
        // ...
    }
```

```csharp
    [Theory, JsonFileData("config.json", sectionKey: "cases")]
    public void SectionedTest(int x, int y)
    {
        // ...
    }
```

2) `CustomAutoDataAttribute`
- A simplified attribute for use with `AutoFixture` + `AutoMoq`.
- Configuration:
  - Adds `AutoMoqCustomization` with `ConfigureMembers = true`.
  - Removes `ThrowingRecursionBehavior` and adds `OmitOnRecursionBehavior` to safely generate object graphs.
- Example:
```csharp
    [Theory, CustomAutoData]
    public void AutoFixtureTest(MyService sut, int n)
    {
        Assert.NotNull(sut);
    }
```

3) `MockExtension.AddMocks`
- An extension for `IServiceCollection`: for each provided `Type` it registers:
  - `Mock<T>` as scoped,
  - `T` (mock.Object) as scoped.
- Removes existing registrations for the type before adding the mock.
- Example:
```csharp
    var services = new ServiceCollection();
    services.AddMocks(typeof(IMyService), typeof(IOtherService));
```
or with generics (implemented via reflection for each type in the code).

License
- MIT

# XUnit3Helper.Integration + XUnit3Helper.StartupModule

## XUnit3Helper.Integration

A short guide on using helper utilities for integration testing ASP.NET Core applications.

## Overview
The `XUnit3Helper.Integration` project provides primitives to run a test `WebApplication` with a real Kestrel server and conveniences for controller testing:
- Test application factory with Kestrel — `BaseWebApplicationFactory`,
- Base class for controller tests — `BaseControllerTests`.

The goal is to simplify starting a test application on a random free port, injecting startup modules, and registering controllers from a specific assembly.

## Usage
1. Create a factory by inheriting from `BaseWebApplicationFactory<TYourStartupModule>`:
   - implement `ServerKey` (`Guid`), `ControllersAssembly` (`Assembly`), and override `Environment` and `ServiceTypeForMock` if needed.
2. Implement `TYourStartupModule : BaseStartupModule` with a constructor `(IWebHostEnvironment, ConfigurationManager)`.
3. In your test, inherit from `BaseControllerTests<TYourStartupModule, TYourFactory>` or use the factory/fixture manually and call `CreateClient()`.

Important: `CreateStartupModule` creates the startup module instance using reflection — ensure your startup module contains a constructor with the required signature.

## XUnit3Helper.StartupModule

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
