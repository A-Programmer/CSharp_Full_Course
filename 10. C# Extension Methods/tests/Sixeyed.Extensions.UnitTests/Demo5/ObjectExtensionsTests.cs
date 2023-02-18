using Sixeyed.Extensions.Samples.Demo3;
using Sixeyed.Extensions.Samples.Demo3.Impl;
using Sixeyed.Extensions.Samples.Demo5;

using System.Diagnostics;

namespace Sixeyed.Extensions.UnitTests.Demo5;

[TestClass]
public class ObjectExtensionsTests
{
    [TestMethod]
    public void ToJsonString_ReturnsObjectsAsJsonString()
    {
        var obj1 = int.MaxValue;
        Debug.WriteLine($"obj1: {obj1.ToJsonString()}");

        var obj2 = new DateTime(2023, 01, 20);
        Debug.WriteLine($"obj2: {obj2.ToJsonString()}");

        var obj3 = new ReferenceDataItem
        {
            Code = "xyz",
            Description = "123"
        };
        Debug.WriteLine($"obj3: {obj3.ToJsonString()}");

        IEnumerable<IReferenceDataSource> obj4 = new List<IReferenceDataSource>
        {
            new SqlReferenceDataSource(),
            new XmlReferenceDataSource()
        };
        Debug.WriteLine($"obj4: {obj4.ToJsonString()}");
    }

    [TestMethod]
    public void GetJsonTypeDescription()
    {
        var obj1 = int.MaxValue;
        Debug.WriteLine($"obj1: {obj1.GetJsonTypeDescription()}");

        var obj2 = new DateTime(2023, 01, 20);
        Debug.WriteLine($"obj2: {obj2.GetJsonTypeDescription()}");

        var obj3 = new ReferenceDataItem
        {
            Code = "xyz",
            Description = "123"
        };
        Debug.WriteLine($"obj3: {obj3.GetJsonTypeDescription()}");

        IEnumerable<IReferenceDataSource> obj4 = new List<IReferenceDataSource>
        {
            new SqlReferenceDataSource(),
            new XmlReferenceDataSource()
        };
        Debug.WriteLine($"obj4: {obj4.GetJsonTypeDescription()}");
    }
}
