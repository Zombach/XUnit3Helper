# XUnit3Helper

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/src/XUnit3Helper/README.md)
[![ru](https://img.shields.io/badge/lang-ru-green.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/src/XUnit3Helper/README.ru.md)

Утилитная библиотека для удобной работы с `xUnit v3`.
Предназначена для ускорения написания параметризованных тестов и упрощения подготовки моков в контейнерах DI.

Ключевые возможности
- Атрибут `JsonFileDataAttribute` — загрузка данных для `Theory` из JSON-файла (несколько форматов, секции).
- Атрибут `CustomAutoDataAttribute` — готовая конфигурация `AutoFixture` + `AutoMoq` (включая конфигурацию `ConfigureMembers` и поведение рекурсий).
- Расширение `MockExtension.AddMocks` — массовая регистрация моков `Moq` в `IServiceCollection`.
- Вспомогательный генератор `GenerateTestDataExtension` и модель `TestData` — поддержка десериализации JSON в наборы параметров до 15 аргументов.
- Поддерживаемые таргеты: `net8.0`, `net9.0`, `net10.0`.

## Использование
1) `JsonFileDataAttribute`
- Конструктор: `JsonFileDataAttribute(string filePath, bool simpleTypeJson = false, string? sectionKey = null)`
- Поведение:
  - Проверяет существование файла.
  - При указании `sectionKey` извлекает соответствующую секцию JSON (по ключу верхнего уровня).
  - Поддерживает два формата JSON:
    - "Комплексный" — массив объектов с полями `P1`, `P2`, ... (соответствует моделям `TestData`).
    - "Простой" (`simpleTypeJson = true`) — массив массивов или массив строк/чисел, где каждый элемент массива соответствует параметру теста.
  - Ограничение: до 15 параметров (вся логика генерации тестовых рядов реализована для 1..15 параметров).
- Примеры:
Формат комплексных данных (рекомендуемый):
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
Формат простых типов (`simpleTypeJson = true`):
```json
[
    [1, "a", true],
    [2, "b", false]
]
```

Применение в тестах:
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
- Упрощённый атрибут для использования с `AutoFixture` + `AutoMoq`.
- Конфигурация:
  - Добавляет `AutoMoqCustomization` с `ConfigureMembers = true`.
  - Убирает поведение `ThrowingRecursionBehavior` и добавляет `OmitOnRecursionBehavior` для безопасной генерации графов объектов.
- Пример использования:
```csharp
    [Theory, CustomAutoData]
    public void AutoFixtureTest(MyService sut, int n)
    {
        Assert.NotNull(sut);
    }
```

3) `MockExtension.AddMocks`
- Расширение для `IServiceCollection`: регистрирует для каждого переданного `Type`:
  - `Mock<T>` как scoped,
  - `T` (mock.Object) как scoped.
- Удаляет существующие регистрации для типа перед добавлением мока.
- Пример:
```csharp
    var services = new ServiceCollection();
    services.AddMocks(typeof(IMyService), typeof(IOtherService));
```
или с дженериками (в коде реализована via reflection для каждого типа).

Лицензия
- MIT
