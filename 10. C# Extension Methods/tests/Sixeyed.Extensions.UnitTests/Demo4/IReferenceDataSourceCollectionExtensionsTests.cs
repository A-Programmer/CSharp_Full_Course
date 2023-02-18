using System.Collections;
using Sixeyed.Extensions.Samples.Demo3;
using Sixeyed.Extensions.Samples.Demo3.Impl;

namespace Sixeyed.Extensions.UnitTests.Demo4;

[TestClass]
public class IReferenceDataSourceCollectionExtensionsTests
{
    [TestMethod]
    public void GetAllItemsByCode_Array()
    {
        var sources = new IReferenceDataSource[] { new SqlReferenceDataSource(),
            new XmlReferenceDataSource(), new ApiReferenceDataSource() };
        var items = sources.GetAllItemsByCode("xyz");
        Assert.AreEqual(6, items.Count());
    }

    [TestMethod]
    public void GetAllItemsByCode_ArrayList()
    {
        var sources = new ArrayList { new SqlReferenceDataSource(),
            new XmlReferenceDataSource(), new ApiReferenceDataSource() };
        sources.Add("I am not a reference data source");
        var items = sources.GetAllItemsByCode("xyz");
        Assert.AreEqual(6, items.Count());
    }

    [TestMethod]
    public void GetAllItemsByCode_IEnumerable()
    {
        var sources = new List<IReferenceDataSource> { new SqlReferenceDataSource(),
            new XmlReferenceDataSource(), new ApiReferenceDataSource() };
        
        var items = sources.GetAllItemsByCode("xyz");
        Assert.AreEqual(6, items.Count());
    }

    [TestMethod]
    public void GetAllItemsByCode_IEnumerable_HashSet()
    {
        var sources = new HashSet<IReferenceDataSource> { new SqlReferenceDataSource(),
            new XmlReferenceDataSource(), new ApiReferenceDataSource() };
        
        var items = sources.GetAllItemsByCode("xyz");
        Assert.AreEqual(6, items.Count());
    }
}
