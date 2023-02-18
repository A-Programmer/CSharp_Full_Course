using System.Xml;

namespace Sixeyed.Extensions.UnitTests.Demo2;

[TestClass]
public class DateTimeExtensionsTests
{
    [TestMethod]
    public void ToXmlDateTimeWithoutOptionalParameter_InputIsValid_ShouldReturnCorrectValue()
    {
        DateTime dateTime = new(2013, 10, 24, 13, 10, 15, 951);
        Assert.AreEqual("2013-10-24T13:10:15.951Z", dateTime.ToXmlDateTime());
    }
    [TestMethod]
    public void ToXmlDateTimeSecondWithOptionalParameter_InputIsValid_ShouldReturnCorrectValue()
    {
        DateTime dateTime = new(2013, 10, 24, 13, 10, 15, 951);
        Assert.AreEqual("2013-10-24T13:10:15.951+03:30", dateTime.ToXmlDateTime(XmlDateTimeSerializationMode.Local));
    }
}
