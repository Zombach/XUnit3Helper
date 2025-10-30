namespace XUnit3Helper.Models;

public class TestData<TParameter1, TParameter2, TParameter3, TParameter4,
    TParameter5, TParameter6, TParameter7, TParameter8,
    TParameter9, TParameter10, TParameter11, TParameter12>
    : TestData<TParameter1, TParameter2, TParameter3, TParameter4,
        TParameter5, TParameter6, TParameter7, TParameter8,
        TParameter9, TParameter10, TParameter11>
{
    public TParameter12 P12 { get; init; }
}

public class TestData<TParameter1, TParameter2, TParameter3, TParameter4,
    TParameter5, TParameter6, TParameter7, TParameter8,
    TParameter9, TParameter10, TParameter11>
    : TestData<TParameter1, TParameter2, TParameter3, TParameter4,
        TParameter5, TParameter6, TParameter7,
        TParameter8, TParameter9, TParameter10>
{
    public TParameter11 P11 { get; init; }
}

public class TestData<TParameter1, TParameter2, TParameter3, TParameter4,
    TParameter5, TParameter6, TParameter7,
    TParameter8, TParameter9, TParameter10>
    : TestData<TParameter1, TParameter2, TParameter3,
        TParameter4, TParameter5, TParameter6,
        TParameter7, TParameter8, TParameter9>
{
    public TParameter10 P10 { get; init; }
}

public class TestData<TParameter1, TParameter2, TParameter3,
    TParameter4, TParameter5, TParameter6,
    TParameter7, TParameter8, TParameter9>
    : TestData<TParameter1, TParameter2, TParameter3,
        TParameter4, TParameter5, TParameter6,
        TParameter7, TParameter8>
{
    public TParameter9 P9 { get; init; }
}

public class TestData<TParameter1, TParameter2, TParameter3, TParameter4,
    TParameter5, TParameter6, TParameter7, TParameter8>
    : TestData<TParameter1, TParameter2, TParameter3, TParameter4,
        TParameter5, TParameter6, TParameter7>
{
    public TParameter8 P8 { get; init; }
}

public class TestData<TParameter1, TParameter2, TParameter3, TParameter4,
    TParameter5, TParameter6, TParameter7>
    : TestData<TParameter1, TParameter2, TParameter3,
        TParameter4, TParameter5, TParameter6>
{
    public TParameter7 P7 { get; init; }
}

public class TestData<TParameter1, TParameter2, TParameter3,
    TParameter4, TParameter5, TParameter6>
    : TestData<TParameter1, TParameter2, TParameter3,
        TParameter4, TParameter5>
{
    public TParameter6 P6 { get; init; }
}

public class TestData<TParameter1, TParameter2, TParameter3,
    TParameter4, TParameter5>
    : TestData<TParameter1, TParameter2, TParameter3, TParameter4>
{
    public TParameter5 P5 { get; init; }
}

public class TestData<TParameter1, TParameter2, TParameter3, TParameter4>
    : TestData<TParameter1, TParameter2, TParameter3>
{
    public TParameter4 P4 { get; init; }
}

public class TestData<TParameter1, TParameter2, TParameter3>
    : TestData<TParameter1, TParameter2>
{
    public TParameter3 P3 { get; init; }
}

public class TestData<TParameter1, TParameter2>
    : TestData<TParameter1>
{
    public TParameter2 P2 { get; init; }
}

public class TestData<TParameter1>
{
    public TParameter1 P1 { get; init; }
}
