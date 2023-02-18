using Sixeyed.Extensions.Samples.Demo1;

namespace Sixeyed.Extensions.UnitTests.Demo1;

[TestClass]
public class LegacyExtensionsTests
{
    [TestMethod]
    public void ToLegacyFormat_InputIsValid_C20()
    {
        var dateTime = new DateTime(1920, 12, 31);
        Assert.AreEqual("0201231", dateTime.ToLegacyFormat());
    }

    [TestMethod]
    public void ToLegacyFormat_InputIsValid_C21()
    {
        var dateTime = new DateTime(2013, 10, 31);
        Assert.AreEqual("1131031", dateTime.ToLegacyFormat());
    }

    [TestMethod]
    public void ToLegacyFormat_InputIsValid_ReturnsCorrectLegacyNameFormat()
    {
        var name = "Kamran Sadin";
        Assert.AreEqual("SADIN, KAMRAN", name.ToLegacyFormat());
    }
}
