using System.Diagnostics;
using Sixeyed.Extensions.Samples.Demo6;

namespace Sixeyed.Extensions.UnitTests.Demo6;

[TestClass]
public class InstrumentationTests
{
    [TestMethod]
    public void GetTotalSeconds()
    {
        var instrumentation = new Instrumentation();
        instrumentation.Start();
        Thread.Sleep(750);
        Assert.AreEqual(1, instrumentation.GetElapsedTime());
    }

    [TestMethod]
    public void GetPreciseElapsedTime()
    {
        var instrumentation = new Instrumentation();
        instrumentation.Start();
        Thread.Sleep(750);
        var elapsed = instrumentation.GetPreciseElapsedTime();
        Assert.IsTrue(elapsed >= 0.75 && elapsed < 0.78);
    }

    [TestMethod]
    public void GetReallyPreciseElapsedTime()
    {
        var instrumentation = new Instrumentation();
        instrumentation.StartWithPrecision();
        Thread.Sleep(750);
        Assert.AreEqual(750, instrumentation.GetReallyPreciseElapsedTime());
    } 
}