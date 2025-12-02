using System.Text.Json;
using XUnit3Helper.Impl.FileData.Common;

namespace XUnit3Helper.Impl.FileData;

public sealed class CvsFileDataAttribute(
    string filePath,
    char splitter = ',',
    bool headExists = false)
    : BaseFileDataAttribute(filePath)
{
    protected override async ValueTask<IEnumerable<string>> GetSource(string path)
    {
        if (!File.Exists(path))
        {
            throw new ArgumentException($"Could not find file at path: {path}");
        }

        var lines = await File.ReadAllLinesAsync(path);
        if (lines.Length is 0)
        {
            throw new ArgumentException($"File must not be empty: {path}");
        }

        return lines;
    }

    protected override IEnumerable<ITheoryDataRow> GetTeoryDataRow(
        IEnumerable<string> source,
        Type[] parameterTypes)
    {
        var testDataCollection = headExists
            ? source.Skip(1)
            : source;

        var theoryDataRows = testDataCollection.Where(testData => !string.IsNullOrEmpty(testData))
            .Select(testData =>
        {
            var dataRow = new object[parameterTypes.Length];
            var testDataRow = testData.Split(splitter);
            if (testDataRow.Length != parameterTypes.Length)
            {
                throw new ArgumentException("TestDataRow length and parameterTypes length must be equals");
            }

            for (var index = 0; index < parameterTypes.Length; index++)
            {
                var cell = testDataRow[index];
                var parameterType = parameterTypes[index];
                var parameter = JsonSerializer.Deserialize(cell, parameterType);
                ArgumentNullException.ThrowIfNull(parameter);

                dataRow[index] = parameter;
            }

            return new TheoryDataRow(dataRow);
        });

        return theoryDataRows;
    }
}
