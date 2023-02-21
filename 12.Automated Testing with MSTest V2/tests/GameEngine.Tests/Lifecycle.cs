namespace GameEngine.Tests;

[TestClass]
public class Lifecycle
{
    [TestInitialize]
    public void LifecycleInit()
    {
        Console.WriteLine("Initialization ...");
    }


    [TestCleanup]
    public void LifecycleClean()
    {
        Console.WriteLine("Cleaning up ...");
    }

    [ClassInitialize]
    public static void LifecycleClassInit(TestContext context)
    {
        Console.WriteLine("Class Initialization ...");
    }

    [ClassCleanup]
    public static void LifecycleClassCleanup()
    {
        Console.WriteLine("\tClass Cleanup ...");
    }


    [TestMethod]
    public void TestA()
    {
        Console.WriteLine("\t\tTest A starting");
    }

    [TestMethod]
    public void TestB()
    {
        Console.WriteLine("\t\tTest B starting");
    }
}
