namespace XUnit3Helper.Models;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
/// <typeparam name="TP4">The fourth parameter type.</typeparam>
/// <typeparam name="TP5">The fifth parameter type.</typeparam>
/// <typeparam name="TP6">The sixth parameter type.</typeparam>
/// <typeparam name="TP7">The seventh parameter type.</typeparam>
/// <typeparam name="TP8">The eighth parameter type.</typeparam>
/// <typeparam name="TP9">The ninth parameter type.</typeparam>
/// <typeparam name="TP10">The tenth parameter type.</typeparam>
/// <typeparam name="TP11">The eleventh parameter type.</typeparam>
/// <typeparam name="TP12">The twelfth parameter type.</typeparam>
/// <typeparam name="TP13">The thirteenth parameter type.</typeparam>
/// <typeparam name="TP14">The fourteenth parameter type.</typeparam>
/// <typeparam name="TP15">The fifteenth parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9, TP10,
    TP11, TP12, TP13, TP14, TP15>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    /// <summary>
    /// The fourth data value.
    /// </summary>
    public TP4 P4 { get; init; }

    /// <summary>
    /// The fifth data value.
    /// </summary>
    public TP5 P5 { get; init; }

    /// <summary>
    /// The sixth data value.
    /// </summary>
    public TP6 P6 { get; init; }

    /// <summary>
    /// The seventh data value.
    /// </summary>
    public TP7 P7 { get; init; }

    /// <summary>
    /// The eighth data value.
    /// </summary>
    public TP8 P8 { get; init; }

    /// <summary>
    /// The ninth data value.
    /// </summary>
    public TP9 P9 { get; init; }

    /// <summary>
    /// The tenth data value.
    /// </summary>
    public TP10 P10 { get; init; }

    /// <summary>
    /// The eleventh data value.
    /// </summary>
    public TP11 P11 { get; init; }

    /// <summary>
    /// The twelfth data value.
    /// </summary>
    public TP12 P12 { get; init; }

    /// <summary>
    /// The thirteenth data value.
    /// </summary>
    public TP13 P13 { get; init; }

    /// <summary>
    /// The fourteenth data value.
    /// </summary>
    public TP14 P14 { get; init; }

    /// <summary>
    /// The fifteenth data value.
    /// </summary>
    public TP15 P15 { get; init; }

    public override object?[] GetObjects() =>
    [
        P1, P2, P3, P4, P5,
        P6, P7, P8, P9, P10,
        P11, P12, P13, P14, P15
    ];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11, TP12, TP13, TP14, TP15>(P1, P2, P3, P4, P5,
        P6, P7, P8, P9, P10,
        P11, P12, P13, P14, P15);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
/// <typeparam name="TP4">The fourth parameter type.</typeparam>
/// <typeparam name="TP5">The fifth parameter type.</typeparam>
/// <typeparam name="TP6">The sixth parameter type.</typeparam>
/// <typeparam name="TP7">The seventh parameter type.</typeparam>
/// <typeparam name="TP8">The eighth parameter type.</typeparam>
/// <typeparam name="TP9">The ninth parameter type.</typeparam>
/// <typeparam name="TP10">The tenth parameter type.</typeparam>
/// <typeparam name="TP11">The eleventh parameter type.</typeparam>
/// <typeparam name="TP12">The twelfth parameter type.</typeparam>
/// <typeparam name="TP13">The thirteenth parameter type.</typeparam>
/// <typeparam name="TP14">The fourteenth parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9, TP10,
    TP11, TP12, TP13, TP14>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    /// <summary>
    /// The fourth data value.
    /// </summary>
    public TP4 P4 { get; init; }

    /// <summary>
    /// The fifth data value.
    /// </summary>
    public TP5 P5 { get; init; }

    /// <summary>
    /// The sixth data value.
    /// </summary>
    public TP6 P6 { get; init; }

    /// <summary>
    /// The seventh data value.
    /// </summary>
    public TP7 P7 { get; init; }

    /// <summary>
    /// The eighth data value.
    /// </summary>
    public TP8 P8 { get; init; }

    /// <summary>
    /// The ninth data value.
    /// </summary>
    public TP9 P9 { get; init; }

    /// <summary>
    /// The tenth data value.
    /// </summary>
    public TP10 P10 { get; init; }

    /// <summary>
    /// The eleventh data value.
    /// </summary>
    public TP11 P11 { get; init; }

    /// <summary>
    /// The twelfth data value.
    /// </summary>
    public TP12 P12 { get; init; }

    /// <summary>
    /// The thirteenth data value.
    /// </summary>
    public TP13 P13 { get; init; }

    /// <summary>
    /// The fourteenth data value.
    /// </summary>
    public TP14 P14 { get; init; }

    public override object?[] GetObjects() =>
    [
        P1, P2, P3, P4, P5,
        P6, P7, P8, P9, P10,
        P11, P12, P13, P14
    ];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11, TP12, TP13, TP14>(P1, P2, P3, P4, P5,
        P6, P7, P8, P9, P10,
        P11, P12, P13, P14);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
/// <typeparam name="TP4">The fourth parameter type.</typeparam>
/// <typeparam name="TP5">The fifth parameter type.</typeparam>
/// <typeparam name="TP6">The sixth parameter type.</typeparam>
/// <typeparam name="TP7">The seventh parameter type.</typeparam>
/// <typeparam name="TP8">The eighth parameter type.</typeparam>
/// <typeparam name="TP9">The ninth parameter type.</typeparam>
/// <typeparam name="TP10">The tenth parameter type.</typeparam>
/// <typeparam name="TP11">The eleventh parameter type.</typeparam>
/// <typeparam name="TP12">The twelfth parameter type.</typeparam>
/// <typeparam name="TP13">The thirteenth parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9, TP10,
    TP11, TP12, TP13>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    /// <summary>
    /// The fourth data value.
    /// </summary>
    public TP4 P4 { get; init; }

    /// <summary>
    /// The fifth data value.
    /// </summary>
    public TP5 P5 { get; init; }

    /// <summary>
    /// The sixth data value.
    /// </summary>
    public TP6 P6 { get; init; }

    /// <summary>
    /// The seventh data value.
    /// </summary>
    public TP7 P7 { get; init; }

    /// <summary>
    /// The eighth data value.
    /// </summary>
    public TP8 P8 { get; init; }

    /// <summary>
    /// The ninth data value.
    /// </summary>
    public TP9 P9 { get; init; }

    /// <summary>
    /// The tenth data value.
    /// </summary>
    public TP10 P10 { get; init; }

    /// <summary>
    /// The eleventh data value.
    /// </summary>
    public TP11 P11 { get; init; }

    /// <summary>
    /// The twelfth data value.
    /// </summary>
    public TP12 P12 { get; init; }

    /// <summary>
    /// The thirteenth data value.
    /// </summary>
    public TP13 P13 { get; init; }

    public override object?[] GetObjects() =>
    [
        P1, P2, P3, P4, P5,
        P6, P7, P8, P9, P10,
        P11, P12, P13
    ];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11, TP12, TP13>(P1, P2, P3, P4, P5,
        P6, P7, P8, P9, P10,
        P11, P12, P13);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
/// <typeparam name="TP4">The fourth parameter type.</typeparam>
/// <typeparam name="TP5">The fifth parameter type.</typeparam>
/// <typeparam name="TP6">The sixth parameter type.</typeparam>
/// <typeparam name="TP7">The seventh parameter type.</typeparam>
/// <typeparam name="TP8">The eighth parameter type.</typeparam>
/// <typeparam name="TP9">The ninth parameter type.</typeparam>
/// <typeparam name="TP10">The tenth parameter type.</typeparam>
/// <typeparam name="TP11">The eleventh parameter type.</typeparam>
/// <typeparam name="TP12">The twelfth parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9, TP10,
    TP11, TP12>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    /// <summary>
    /// The fourth data value.
    /// </summary>
    public TP4 P4 { get; init; }

    /// <summary>
    /// The fifth data value.
    /// </summary>
    public TP5 P5 { get; init; }

    /// <summary>
    /// The sixth data value.
    /// </summary>
    public TP6 P6 { get; init; }

    /// <summary>
    /// The seventh data value.
    /// </summary>
    public TP7 P7 { get; init; }

    /// <summary>
    /// The eighth data value.
    /// </summary>
    public TP8 P8 { get; init; }

    /// <summary>
    /// The ninth data value.
    /// </summary>
    public TP9 P9 { get; init; }

    /// <summary>
    /// The tenth data value.
    /// </summary>
    public TP10 P10 { get; init; }

    /// <summary>
    /// The eleventh data value.
    /// </summary>
    public TP11 P11 { get; init; }

    /// <summary>
    /// The twelfth data value.
    /// </summary>
    public TP12 P12 { get; init; }

    public override object?[] GetObjects() =>
    [
        P1, P2, P3, P4, P5,
        P6, P7, P8, P9, P10,
        P11, P12
    ];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11, TP12>(P1, P2, P3, P4, P5,
        P6, P7, P8, P9, P10,
        P11, P12);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
/// <typeparam name="TP4">The fourth parameter type.</typeparam>
/// <typeparam name="TP5">The fifth parameter type.</typeparam>
/// <typeparam name="TP6">The sixth parameter type.</typeparam>
/// <typeparam name="TP7">The seventh parameter type.</typeparam>
/// <typeparam name="TP8">The eighth parameter type.</typeparam>
/// <typeparam name="TP9">The ninth parameter type.</typeparam>
/// <typeparam name="TP10">The tenth parameter type.</typeparam>
/// <typeparam name="TP11">The eleventh parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9, TP10,
    TP11>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    /// <summary>
    /// The fourth data value.
    /// </summary>
    public TP4 P4 { get; init; }

    /// <summary>
    /// The fifth data value.
    /// </summary>
    public TP5 P5 { get; init; }

    /// <summary>
    /// The sixth data value.
    /// </summary>
    public TP6 P6 { get; init; }

    /// <summary>
    /// The seventh data value.
    /// </summary>
    public TP7 P7 { get; init; }

    /// <summary>
    /// The eighth data value.
    /// </summary>
    public TP8 P8 { get; init; }

    /// <summary>
    /// The ninth data value.
    /// </summary>
    public TP9 P9 { get; init; }

    /// <summary>
    /// The tenth data value.
    /// </summary>
    public TP10 P10 { get; init; }

    /// <summary>
    /// The eleventh data value.
    /// </summary>
    public TP11 P11 { get; init; }

    public override object?[] GetObjects() =>
    [
        P1, P2, P3, P4, P5,
        P6, P7, P8, P9, P10,
        P11
    ];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11>(P1, P2, P3, P4, P5,
        P6, P7, P8, P9, P10,
        P11);
}
/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
/// <typeparam name="TP4">The fourth parameter type.</typeparam>
/// <typeparam name="TP5">The fifth parameter type.</typeparam>
/// <typeparam name="TP6">The sixth parameter type.</typeparam>
/// <typeparam name="TP7">The seventh parameter type.</typeparam>
/// <typeparam name="TP8">The eighth parameter type.</typeparam>
/// <typeparam name="TP9">The ninth parameter type.</typeparam>
/// <typeparam name="TP10">The tenth parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9, TP10>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    /// <summary>
    /// The fourth data value.
    /// </summary>
    public TP4 P4 { get; init; }

    /// <summary>
    /// The fifth data value.
    /// </summary>
    public TP5 P5 { get; init; }

    /// <summary>
    /// The sixth data value.
    /// </summary>
    public TP6 P6 { get; init; }

    /// <summary>
    /// The seventh data value.
    /// </summary>
    public TP7 P7 { get; init; }

    /// <summary>
    /// The eighth data value.
    /// </summary>
    public TP8 P8 { get; init; }

    /// <summary>
    /// The ninth data value.
    /// </summary>
    public TP9 P9 { get; init; }

    /// <summary>
    /// The tenth data value.
    /// </summary>
    public TP10 P10 { get; init; }

    public override object?[] GetObjects() =>
    [
        P1, P2, P3, P4, P5,
        P6, P7, P8, P9, P10
    ];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10>(P1, P2, P3, P4, P5,
        P6, P7, P8, P9, P10);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
/// <typeparam name="TP4">The fourth parameter type.</typeparam>
/// <typeparam name="TP5">The fifth parameter type.</typeparam>
/// <typeparam name="TP6">The sixth parameter type.</typeparam>
/// <typeparam name="TP7">The seventh parameter type.</typeparam>
/// <typeparam name="TP8">The eighth parameter type.</typeparam>
/// <typeparam name="TP9">The ninth parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    /// <summary>
    /// The fourth data value.
    /// </summary>
    public TP4 P4 { get; init; }

    /// <summary>
    /// The fifth data value.
    /// </summary>
    public TP5 P5 { get; init; }

    /// <summary>
    /// The sixth data value.
    /// </summary>
    public TP6 P6 { get; init; }

    /// <summary>
    /// The seventh data value.
    /// </summary>
    public TP7 P7 { get; init; }

    /// <summary>
    /// The eighth data value.
    /// </summary>
    public TP8 P8 { get; init; }

    /// <summary>
    /// The ninth data value.
    /// </summary>
    public TP9 P9 { get; init; }

    public override object?[] GetObjects() =>
    [
        P1, P2, P3, P4, P5,
        P6, P7, P8, P9
    ];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9>(P1, P2, P3, P4, P5,
        P6, P7, P8, P9);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
/// <typeparam name="TP4">The fourth parameter type.</typeparam>
/// <typeparam name="TP5">The fifth parameter type.</typeparam>
/// <typeparam name="TP6">The sixth parameter type.</typeparam>
/// <typeparam name="TP7">The seventh parameter type.</typeparam>
/// <typeparam name="TP8">The eighth parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    /// <summary>
    /// The fourth data value.
    /// </summary>
    public TP4 P4 { get; init; }

    /// <summary>
    /// The fifth data value.
    /// </summary>
    public TP5 P5 { get; init; }

    /// <summary>
    /// The sixth data value.
    /// </summary>
    public TP6 P6 { get; init; }

    /// <summary>
    /// The seventh data value.
    /// </summary>
    public TP7 P7 { get; init; }

    /// <summary>
    /// The eighth data value.
    /// </summary>
    public TP8 P8 { get; init; }

    public override object?[] GetObjects() =>
    [
        P1, P2, P3, P4, P5,
        P6, P7, P8
    ];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8>(P1, P2, P3, P4, P5,
        P6, P7, P8);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
/// <typeparam name="TP4">The fourth parameter type.</typeparam>
/// <typeparam name="TP5">The fifth parameter type.</typeparam>
/// <typeparam name="TP6">The sixth parameter type.</typeparam>
/// <typeparam name="TP7">The seventh parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    /// <summary>
    /// The fourth data value.
    /// </summary>
    public TP4 P4 { get; init; }

    /// <summary>
    /// The fifth data value.
    /// </summary>
    public TP5 P5 { get; init; }

    /// <summary>
    /// The sixth data value.
    /// </summary>
    public TP6 P6 { get; init; }

    /// <summary>
    /// The seventh data value.
    /// </summary>
    public TP7 P7 { get; init; }

    public override object?[] GetObjects() =>
    [
        P1, P2, P3, P4, P5,
        P6, P7
    ];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7>(P1, P2, P3, P4, P5,
        P6, P7);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
/// <typeparam name="TP4">The fourth parameter type.</typeparam>
/// <typeparam name="TP5">The fifth parameter type.</typeparam>
/// <typeparam name="TP6">The sixth parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    /// <summary>
    /// The fourth data value.
    /// </summary>
    public TP4 P4 { get; init; }

    /// <summary>
    /// The fifth data value.
    /// </summary>
    public TP5 P5 { get; init; }

    /// <summary>
    /// The sixth data value.
    /// </summary>
    public TP6 P6 { get; init; }

    public override object?[] GetObjects() =>
    [
        P1, P2, P3, P4, P5,
        P6
    ];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5,
        TP6>(P1, P2, P3, P4, P5,
        P6);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
/// <typeparam name="TP4">The fourth parameter type.</typeparam>
/// <typeparam name="TP5">The fifth parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3, TP4, TP5>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    /// <summary>
    /// The fourth data value.
    /// </summary>
    public TP4 P4 { get; init; }

    /// <summary>
    /// The fifth data value.
    /// </summary>
    public TP5 P5 { get; init; }

    public override object?[] GetObjects() => [P1, P2, P3, P4, P5];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3, TP4, TP5>(P1, P2, P3, P4, P5);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
/// <typeparam name="TP4">The fourth parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3, TP4>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    /// <summary>
    /// The fourth data value.
    /// </summary>
    public TP4 P4 { get; init; }

    public override object?[] GetObjects() => [P1, P2, P3, P4];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3, TP4>(P1, P2, P3, P4);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
/// <typeparam name="TP3">The third parameter type.</typeparam>
public sealed class TestData<TP1, TP2, TP3>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    /// <summary>
    /// The third data value.
    /// </summary>
    public TP3 P3 { get; init; }

    public override object?[] GetObjects() => [P1, P2, P3];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2, TP3>(P1, P2, P3);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
/// <typeparam name="TP2">The second parameter type.</typeparam>
public sealed class TestData<TP1, TP2>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    /// <summary>
    /// The second data value.
    /// </summary>
    public TP2 P2 { get; init; }

    public override object?[] GetObjects() => [P1, P2];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1, TP2>(P1, P2);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TP1">The first parameter type.</typeparam>
public sealed class TestData<TP1>
    : BaseTestData
{
    /// <summary>
    /// The first data value.
    /// </summary>
    public TP1 P1 { get; init; }

    public override object?[] GetObjects() => [P1];

    public override ITheoryDataRow GetTheoryDataRow() => new TheoryDataRow<TP1>(P1);
}

public abstract class BaseTestData
{
    public abstract object?[] GetObjects();
    public abstract ITheoryDataRow GetTheoryDataRow();
}
