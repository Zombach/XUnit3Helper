using XUnit3Helper.Impl;

namespace XUnit3Helper.Tests.Impl;

public sealed class JsonFileDataAttributeTests
{
    public sealed class P2
    {
        public sealed class P2Child
        {
            public bool Boolean { get; set; }
        }

        public string Text { get; set; }
        public P2Child Child { get; set; }
    }

    public sealed class P3
    {
        public sealed class P3Child
        {
            public bool Boolean { get; set; }
        }

        public int Integer { get; set; }
        public string Text { get; set; }
        public P3Child Child { get; set; }
    }

    [Theory]
    [JsonFileData("assets/data.json")]
    public Task JsonFileDataTest(int integer, P2 parameter, P3 expected)
    {
        Assert.Equal(expected.Integer, integer);
        Assert.Equal(expected.Text, parameter.Text);
        Assert.Equal(expected.Child.Boolean, parameter.Child.Boolean);

        return Task.CompletedTask;
    }

    [Theory]
    [JsonFileData("assets/data-with-section.json", sectionKey: "SectionKey2")]
    public Task JsonFileDataBySectionKeyTest(int integer, P2 parameter, P3 expected)
    {
        Assert.Equal(2, expected.Integer);
        Assert.Equal(expected.Integer, integer);

        Assert.Equal("2", expected.Text);
        Assert.Equal(expected.Text, parameter.Text);

        Assert.True(expected.Child.Boolean);
        Assert.Equal(expected.Child.Boolean, parameter.Child.Boolean);

        return Task.CompletedTask;
    }

    //[Theory]
    //[JsonFileData("assets/simple-type-data.json", simpleTypeJson: true)]
    //public Task SimpleTypeJsonFileDataTest(int integer, bool boolean, string text)
    //{
    //    Assert.Equal(text, $"{integer}{boolean}");

    //    return Task.CompletedTask;
    //}

    [Theory]
    [JsonFileData(
        "assets/simple-type-data-with-section.json",
        simpleTypeJson: true,
        sectionKey: "SectionKey2")]
    public Task SimpleTypeJsonFileDataBySectionKeyTest(int integer, bool boolean, string text)
    {
        Assert.Equal(text, integer is 3 ? "3false" : "4true");

        var actual = $"{integer}{boolean}".ToLower();
        Assert.Equal(text, actual);

        return Task.CompletedTask;
    }
}
