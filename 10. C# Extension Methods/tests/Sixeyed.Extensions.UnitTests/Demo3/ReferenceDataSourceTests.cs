using Sixeyed.Extensions.Samples.Demo3;
using Sixeyed.Extensions.Samples.Demo3.Impl;

namespace Sixeyed.Extensions.UnitTests.Demo3;

[TestClass]
public class ReferenceDataSourceTests
{
    [TestMethod]
    public void GetItems_ReturnsItems()
    {
        IReferenceDataSource source;
        
        source = new SqlReferenceDataSource();
        Assert.AreEqual(2, source.GetItems().Count());

        source = new XmlReferenceDataSource();
        Assert.AreEqual(2, source.GetItems().Count());
        
        source = new ApiReferenceDataSource();
        Assert.AreEqual(2, source.GetItems().Count());
    }
    
    [TestMethod]
    public void GetItemsByCode_Sql_ReturnsItems()
    {
        IReferenceDataSource source;
        
        source = new SqlReferenceDataSource();
        Assert.AreEqual(2, source.GetItemsByCode("xyz").Count());
    }

    [TestMethod]
    public void GetItemsByCode_Xml_ReturnsItems()
    {
        IReferenceDataSource source;
        
        source = new XmlReferenceDataSource();
        Assert.AreEqual(2, source.GetItemsByCode("xyz").Count());
    }

    [TestMethod]
    public void GetItemsByCode_Api_ReturnsItems()
    {
        IReferenceDataSource source;
        
        source = new ApiReferenceDataSource();
        Assert.AreEqual(2, source.GetItemsByCode("xyz").Count());
    }
}
