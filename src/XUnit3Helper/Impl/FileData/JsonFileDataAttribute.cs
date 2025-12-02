using System.Reflection;
using System.Text.Json;
using XUnit3Helper.Extensions;
using XUnit3Helper.Impl.FileData.Common;

namespace XUnit3Helper.Impl.FileData;

public sealed class JsonFileDataAttribute(
    string filePath,
    bool simpleType = false,
    string? sectionKey = null)
    : BaseFileDataAttribute(filePath)
{
    protected override void CheckParameters(Type[] parameterTypes)
    {
        if (!simpleType && parameterTypes.Length > 15)
        {
            throw new ArgumentException($"SimpleType parameterTypes must be > 0 and < 15: {parameterTypes}");
        }

        base.CheckParameters(parameterTypes);
    }

    protected override async ValueTask<IEnumerable<string>> GetSource(string path)
    {
        if (!File.Exists(path))
        {
            throw new ArgumentException($"Could not find file at path: {path}");
        }

        var fileData = await File.ReadAllTextAsync(path);
        if (string.IsNullOrEmpty(fileData))
        {
            throw new ArgumentException($"File must not be empty: {path}");
        }

        if (!string.IsNullOrEmpty(sectionKey))
        {
            fileData = GetSectionData(fileData, sectionKey);
        }

        return [fileData];
    }

    protected override IEnumerable<ITheoryDataRow> GetTeoryDataRow(
        IEnumerable<string> source,
        Type[] parameterTypes)
    {
        var fileData = source.First();

        var theoryDataRows = simpleType
            ? CreateSimpleTheoryDataRows(fileData, parameterTypes)
            : CreateTheoryDataRows(fileData, parameterTypes);

        return theoryDataRows;
    }

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

    private static string GetSectionData(string fileData, string sectionKey)
    {
        var options = new JsonDocumentOptions { AllowTrailingCommas = true, CommentHandling = JsonCommentHandling.Skip };
        using var jsonDocument = JsonDocument.Parse(fileData, options);
        using var objectEnumerator = jsonDocument.RootElement.EnumerateObject();

        while (objectEnumerator.MoveNext())
        {
            if (objectEnumerator.Current.Name == sectionKey)
            {
                return objectEnumerator.Current.Value.GetRawText();
            }
        }

        throw new ArgumentException("Не обнаружена секция: {sectionKey}");
    }
}
