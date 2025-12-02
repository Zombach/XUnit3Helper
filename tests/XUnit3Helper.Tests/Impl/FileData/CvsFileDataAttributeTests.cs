using XUnit3Helper.Impl.FileData;

namespace XUnit3Helper.Tests.Impl.FileData;

public sealed class CvsFileDataAttributeTests
{
    [Theory]
    [CvsFileData("assets/cvs/data.cvs")]
    public ValueTask CvsFileDataTest(int index, int first, string second)
    {
        switch (index)
        {
            case 0:
            {
                Assert.Equal(1, first);
                Assert.Equal("2", second);
                break;
            }

            case 1:
            {
                Assert.Equal(-100, first);
                Assert.Equal("Text", second);
                break;
            }
        }

        return ValueTask.CompletedTask;
    }

    [Theory]
    [CvsFileData("assets/cvs/data2.cvs")]
    public ValueTask CvsFileDataTest2(int index, bool boolean, int first, string second, double last)
    {
        switch (index)
        {
            case 0:
                {
                    Assert.True(boolean);
                    Assert.Equal(1, first);
                    Assert.Equal("2", second);
                    Assert.Equal(2.3, last);
                    break;
                }

            case 1:
                {
                    Assert.False(boolean);
                    Assert.Equal(9, first);
                    Assert.Equal("1", second);
                    Assert.Equal(1.3, last);
                    break;
                }
        }

        return ValueTask.CompletedTask;
    }
}
