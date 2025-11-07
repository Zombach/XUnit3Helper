using FluentAssertions;
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
        integer.Should().Be(expected.Integer);
        parameter.Text.Should().Be(expected.Text);
        parameter.Child.Boolean.Should().Be(expected.Child.Boolean);

        return Task.CompletedTask;
    }

    [Theory]
    [JsonFileData("assets/data-with-section.json", sectionKey: "SectionKey2")]
    public Task JsonFileDataBySectionKeyTest(int integer, P2 parameter, P3 expected)
    {
        integer.Should().Be(expected.Integer).And.Be(2);
        parameter.Text.Should().Be(expected.Text).And.Be("2");
        parameter.Child.Boolean.Should().Be(expected.Child.Boolean).And.Be(true);

        return Task.CompletedTask;
    }

    [Theory]
    [JsonFileData("assets/simple-type-data.json", simpleTypeJson: true)]
    public Task SimpleTypeJsonFileDataTest(int integer, bool boolean, string text)
    {
        $"{integer}{boolean}".Should().Be(text);

        return Task.CompletedTask;
    }

    [Theory]
    [JsonFileData(
        "assets/simple-type-data-with-section.json",
        simpleTypeJson: true,
        sectionKey: "SectionKey2")]
    public Task SimpleTypeJsonFileDataBySectionKeyTest(int integer, bool boolean, string text)
    {
        var actual = $"{integer}{boolean}".ToLower();
        actual.Should().Be(text).And.Be(integer is 3 ? "3false" : "4true");

        return Task.CompletedTask;
    }
}
