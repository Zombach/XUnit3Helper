using XUnit3Helper.Impl;

namespace XUnit3Helper.Tests.Impl;

public sealed class JsonFileDataAttributeTests
{
    [Theory]
    [JsonFileData("assets/data.json")]
    public async Task JsonAttributeTest(int q, R a)
    {
        var sss = "qwe";
    }

    [Theory]
    [JsonFileData("assets/simple-type-data.json", simpleTypeJson: true)]
    public async Task JsonAttributeTest2(int q, bool t, string a)
    {
        var sss = "qwe";
    }

    public sealed class R
    {
        public int X { get; set; }
        public C C { get; set; }
    }

    public sealed class C
    {
        public string X { get; set; }
    }

}
