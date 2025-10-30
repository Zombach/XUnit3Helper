namespace XUnit3Helper.Models;

public class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9, TP10,
    TP11, TP12, TP13, TP14, TP15>
    : TestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11, TP12, TP13, TP14>
{
    public TP15 P15 { get; init; }
}

public class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9, TP10,
    TP11, TP12, TP13, TP14>
    : TestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11, TP12, TP13>
{
    public TP14 P14 { get; init; }
}

public class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9, TP10,
    TP11, TP12, TP13>
    : TestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11, TP12>
{
    public TP13 P13 { get; init; }
}

public class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9, TP10,
    TP11, TP12>
    : TestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10,
        TP11>
{
    public TP12 P12 { get; init; }
}

public class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9, TP10,
    TP11>
    : TestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9, TP10>
{
    public TP11 P11 { get; init; }
}

public class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9, TP10>
    : TestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8, TP9>
{
    public TP10 P10 { get; init; }
}

public class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8, TP9>
    : TestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7, TP8>
{
    public TP9 P9 { get; init; }
}

public class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7, TP8>
    : TestData<TP1, TP2, TP3, TP4, TP5,
        TP6, TP7>
{
    public TP8 P8 { get; init; }
}

public class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6, TP7>
    : TestData<TP1, TP2, TP3, TP4, TP5,
        TP6>
{
    public TP7 P7 { get; init; }
}

public class TestData<TP1, TP2, TP3, TP4, TP5,
    TP6>
    : TestData<TP1, TP2, TP3, TP4, TP5>
{
    public TP6 P6 { get; init; }
}

public class TestData<TP1, TP2, TP3, TP4, TP5>
    : TestData<TP1, TP2, TP3, TP4>
{
    public TP5 P5 { get; init; }
}

public class TestData<TP1, TP2, TP3, TP4>
    : TestData<TP1, TP2, TP3>
{
    public TP4 P4 { get; init; }
}

public class TestData<TP1, TP2, TP3>
    : TestData<TP1, TP2>
{
    public TP3 P3 { get; init; }
}

public class TestData<TP1, TP2>
    : TestData<TP1>
{
    public TP2 P2 { get; init; }
}

public class TestData<TP1>
{
    public TP1 P1 { get; init; }
}
