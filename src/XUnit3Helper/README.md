# XUnit3Helper

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/src/XUnit3Helper/README.md)
[![ru](https://img.shields.io/badge/lang-ru-green.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/src/XUnit3Helper/README.ru.md)

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
