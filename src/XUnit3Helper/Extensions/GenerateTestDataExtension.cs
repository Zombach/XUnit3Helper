using System.Text.Json;
using XUnit3Helper.Models;

namespace XUnit3Helper.Extensions;

internal static class GenerateTestDataExtension
{
    private static readonly JsonSerializerOptions s_jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TParameter1>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TParameter1>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TParameter1>(testData.P1));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TParameter1, TParameter2>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TParameter1, TParameter2>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TParameter1, TParameter2>(
            testData.P1, testData.P2));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TParameter1, TParameter2, TParameter3>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TParameter1, TParameter2, TParameter3>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TParameter1, TParameter2, TParameter3>(
            testData.P1, testData.P2, testData.P3));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TParameter1, TParameter2, TParameter3,
        TParameter4>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TParameter1, TParameter2, TParameter3,
            TParameter4>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TParameter1, TParameter2, TParameter3,
            TParameter4>(
            testData.P1, testData.P2, testData.P3,
            testData.P4));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TParameter1, TParameter2, TParameter3,
        TParameter4, TParameter5>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5>(
            testData.P1, testData.P2, testData.P3,
            testData.P4, testData.P5));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TParameter1, TParameter2, TParameter3,
        TParameter4, TParameter5, TParameter6>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6>(
            testData.P1, testData.P2, testData.P3,
            testData.P4, testData.P5, testData.P6));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TParameter1, TParameter2, TParameter3,
        TParameter4, TParameter5, TParameter6,
        TParameter7>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6,
            TParameter7>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6,
            TParameter7>(
            testData.P1, testData.P2, testData.P3,
            testData.P4, testData.P5, testData.P6,
            testData.P7));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TParameter1, TParameter2, TParameter3,
        TParameter4, TParameter5, TParameter6,
        TParameter7, TParameter8>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6,
            TParameter7, TParameter8>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6,
            TParameter7, TParameter8>(
            testData.P1, testData.P2, testData.P3,
            testData.P4, testData.P5, testData.P6,
            testData.P7, testData.P8));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TParameter1, TParameter2, TParameter3,
        TParameter4, TParameter5, TParameter6,
        TParameter7, TParameter8, TParameter9>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6,
            TParameter7, TParameter8, TParameter9>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6,
            TParameter7, TParameter8, TParameter9>(
            testData.P1, testData.P2, testData.P3,
            testData.P4, testData.P5, testData.P6,
            testData.P7, testData.P8, testData.P9));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TParameter1, TParameter2, TParameter3,
        TParameter4, TParameter5, TParameter6,
        TParameter7, TParameter8, TParameter9,
        TParameter10>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6,
            TParameter7, TParameter8, TParameter9,
            TParameter10>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6,
            TParameter7, TParameter8, TParameter9,
            TParameter10>(
            testData.P1, testData.P2, testData.P3,
            testData.P4, testData.P5, testData.P6,
            testData.P7, testData.P8, testData.P9,
            testData.P10));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TParameter1, TParameter2, TParameter3,
        TParameter4, TParameter5, TParameter6,
        TParameter7, TParameter8, TParameter9,
        TParameter10, TParameter11>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6,
            TParameter7, TParameter8, TParameter9,
            TParameter10, TParameter11>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6,
            TParameter7, TParameter8, TParameter9,
            TParameter10, TParameter11>(
            testData.P1, testData.P2, testData.P3,
            testData.P4, testData.P5, testData.P6,
            testData.P7, testData.P8, testData.P9,
            testData.P10, testData.P11));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TParameter1, TParameter2, TParameter3,
        TParameter4, TParameter5, TParameter6,
        TParameter7, TParameter8, TParameter9,
        TParameter10, TParameter11, TParameter12>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6,
            TParameter7, TParameter8, TParameter9,
            TParameter10, TParameter11, TParameter12>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TParameter1, TParameter2, TParameter3,
            TParameter4, TParameter5, TParameter6,
            TParameter7, TParameter8, TParameter9,
            TParameter10, TParameter11, TParameter12>(
            testData.P1, testData.P2, testData.P3,
            testData.P4, testData.P5, testData.P6,
            testData.P7, testData.P8, testData.P9,
            testData.P10, testData.P11, testData.P12));
    }
}
