# XUnit3Helper.Integration

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/src/XUnit3Helper.Integration/README.md)
[![ru](https://img.shields.io/badge/lang-ru-green.svg)](https://github.com/Zombach/XUnit3Helper/blob/master/src/XUnit3Helper.Integration/README.ru.md)

Краткое руководство по использованию вспомогательных средств для интеграционных тестов ASP.NET Core приложений.

## Обзор
Проект `XUnit3Helper.Integration` предоставляет готовые примитивы для запуска тестового `WebApplication` с реальным Kestrel-сервером и удобства для тестирования контроллеров:
- фабрика тестового приложения с Kestrel — `BaseWebApplicationFactory`,
- базовый класс для тестов контроллеров — `BaseControllerTests`.

Цель — упростить запуск тестового приложения.

## Как использовать
1. Создайте фабрику, унаследовав `BaseWebApplicationFactory<TYourStartupModule>`:
   - реализуйте `ServerKey` (`Guid`), `ControllersAssembly` (`Assembly`), при необходимости переопределите `Environment` и `ServiceTypeForMock`.
2. Реализуйте `TYourStartupModule : BaseStartupModule` с конструктором `(IWebHostEnvironment, ConfigurationManager)`.
3. В тесте унаследуйте от `BaseControllerTests<TYourStartupModule, TYourFactory>` или используйте фабрику/фикстуру вручную и вызовите `CreateClient()`.

Важно: `CreateStartupModule` создаёт экземпляр стартап-модуля через рефлексию — убедитесь в наличии конструктора с указанной сигнатурой.
