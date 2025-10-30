using System.Text.Json;
using XUnit3Helper.Models;

namespace XUnit3Helper.Extensions;

internal static class GenerateTestDataExtension
{
    private static readonly JsonSerializerOptions s_jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1>(testData.P1));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2>(
            testData.P1, testData.P2));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3>(
            testData.P1, testData.P2, testData.P3));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3, TP4>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3, TP4>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3, TP4>(
            testData.P1, testData.P2, testData.P3, testData.P4));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3, TP4, TP5>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3, TP4, TP5>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5>(
            testData.P1, testData.P2, testData.P3, testData.P4, testData.P5));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3, TP4, TP5,
        TP6>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3, TP4, TP5,
            TP6>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
            TP6>(
            testData.P1, testData.P2, testData.P3, testData.P4, testData.P5,
            testData.P6));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7>(
            testData.P1, testData.P2, testData.P3, testData.P4, testData.P5,
            testData.P6, testData.P7));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8>(
            testData.P1, testData.P2, testData.P3, testData.P4, testData.P5,
            testData.P6, testData.P7, testData.P8));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9>(
            testData.P1, testData.P2, testData.P3, testData.P4, testData.P5,
            testData.P6, testData.P7, testData.P8, testData.P9));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9, TP10>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9, TP10>(
            testData.P1, testData.P2, testData.P3, testData.P4, testData.P5,
            testData.P6, testData.P7, testData.P8, testData.P9, testData.P10));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9, TP10,
            TP11>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9, TP10,
            TP11>(
            testData.P1, testData.P2, testData.P3, testData.P4, testData.P5,
            testData.P6, testData.P7, testData.P8, testData.P9, testData.P10,
            testData.P11));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11, TP12>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9, TP10,
            TP11, TP12>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9, TP10,
            TP11, TP12>(
            testData.P1, testData.P2, testData.P3, testData.P4, testData.P5,
            testData.P6, testData.P7, testData.P8, testData.P9, testData.P10,
            testData.P11, testData.P12));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11, TP12, TP13>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9, TP10,
            TP11, TP12, TP13>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9, TP10,
            TP11, TP12, TP13>(
            testData.P1, testData.P2, testData.P3, testData.P4, testData.P5,
            testData.P6, testData.P7, testData.P8, testData.P9, testData.P10,
            testData.P11, testData.P12, testData.P13));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11, TP12, TP13, TP14>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9, TP10,
            TP11, TP12, TP13, TP14>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9, TP10,
            TP11, TP12, TP13, TP14>(
            testData.P1, testData.P2, testData.P3, testData.P4, testData.P5,
            testData.P6, testData.P7, testData.P8, testData.P9, testData.P10,
            testData.P11, testData.P12, testData.P13, testData.P14));
    }

    public static IEnumerable<ITheoryDataRow> GenerateTestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11, TP12, TP13, TP14, TP15>(string fileData)
    {
        var testDataCollection = JsonSerializer.Deserialize<IEnumerable<TestData<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9, TP10,
            TP11, TP12, TP13, TP14, TP15>>>(
            fileData,
            s_jsonSerializerOptions);

        ArgumentNullException.ThrowIfNull(testDataCollection);

        return testDataCollection.Select(testData => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
            TP6, TP7, TP8, TP9, TP10,
            TP11, TP12, TP13, TP14, TP15>(
            testData.P1, testData.P2, testData.P3, testData.P4, testData.P5,
            testData.P6, testData.P7, testData.P8, testData.P9, testData.P10,
            testData.P11, testData.P12, testData.P13, testData.P14, testData.P15));
    }
}
