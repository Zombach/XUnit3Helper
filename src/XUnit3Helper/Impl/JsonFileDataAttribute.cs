using System.Reflection;
using System.Text.Json;
using Xunit.Internal;
using Xunit.Sdk;
using Xunit.v3;
using XUnit3Helper.Extensions;

namespace XUnit3Helper.Impl;

public sealed class JsonFileDataAttribute(
    string filePath,
    bool simpleTypeJson = false,
    string? sectionName = null)
    : DataAttribute
{
    public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(
        MethodInfo testMethod,
        DisposalTracker disposalTracker)
    {
        ArgumentNullException.ThrowIfNull(testMethod);

        var parameters = testMethod.GetParameters();
        var parameterTypes = parameters.Select(x => x.ParameterType).ToArray();
        if (parameterTypes.Length is 0 or > 13)
        {
            throw new ArgumentException($"parameterTypes should be > 0 < 13: {parameterTypes}");
        }

        var jsonPath = Path.IsPathRooted(filePath)
            ? filePath
            : Path.GetRelativePath(Directory.GetCurrentDirectory(), filePath);

        if (!File.Exists(jsonPath))
        {
            throw new ArgumentException($"Could not find file at path: {jsonPath}");
        }

        var fileData = File.ReadAllText(jsonPath);

        var theoryDataRows = simpleTypeJson
            ? CreateSimpleTheoryDataRows(fileData, parameterTypes)
            : CreateTheoryDataRows(fileData, parameterTypes);

        return ValueTask.FromResult(theoryDataRows.CastOrToReadOnlyCollection());
    }

    public override bool SupportsDiscoveryEnumeration() => true;

    private static IEnumerable<ITheoryDataRow> CreateSimpleTheoryDataRows(
        string fileData,
        Type[] parameterTypes)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<JsonElement[]>>(fileData);
        ArgumentNullException.ThrowIfNull(testDataCollection);

        var theoryDataRows = testDataCollection.Select(testData =>
        {
            var dataRow = new object[parameterTypes.Length];

            for (var index = 0; index < parameterTypes.Length; index++)
            {
                var json = testData[index].GetRawText();
                var parameterType = parameterTypes[index];
                var parameter = JsonSerializer.Deserialize(json, parameterType);
                ArgumentNullException.ThrowIfNull(parameter);

                dataRow[index] = parameter;
            }

            return new TheoryDataRow(dataRow);
        });

        return theoryDataRows;
    }

    private static IEnumerable<ITheoryDataRow> CreateTheoryDataRows(
        string fileData,
        Type[] parameterTypes)
    {
        var methodInfo = typeof(GenerateTestDataExtension)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .FirstOrDefault(method =>
                method.Name == nameof(GenerateTestDataExtension.GenerateTestData)
                && method.GetGenericArguments().Length == parameterTypes.Length);

        ArgumentNullException.ThrowIfNull(methodInfo);
        var genericMethodInfo = methodInfo.MakeGenericMethod([.. parameterTypes]);

        var theoryDataRows = (IEnumerable<ITheoryDataRow>)genericMethodInfo.Invoke(null, [fileData])!;

        return theoryDataRows;
    }
}
