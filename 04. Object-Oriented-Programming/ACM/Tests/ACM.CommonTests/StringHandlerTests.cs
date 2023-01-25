using ACM.Common;

namespace ACM.CommonTests;
public class StringHandlerTests
{
    [Fact]
    public void InsertSpacesTestValid()
    {
        string source = "SonicScrewdriver";
        string expected = "Sonic Screwdriver";

        string actual = source.InsertSpaces();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InsertSpacesTestWithExistingSpace()
    {
        string source = "Sonic Screwdriver";
        string expected = "Sonic Screwdriver";

        string actual = source.InsertSpaces();

        Assert.Equal(expected, actual);
    }
}