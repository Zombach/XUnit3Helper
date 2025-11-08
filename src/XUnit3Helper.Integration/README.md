# XUnit3Helper.Integration

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/src/XUnit3Helper.Integration/README.md)
[![ru](https://img.shields.io/badge/lang-ru-green.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/src/XUnit3Helper.Integration/README.ru.md)

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
