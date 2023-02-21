namespace GameEngine.Tests;

[TestClass]
public class Assembly
{
    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        Console.WriteLine("AssemblyInit");
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        Console.WriteLine("AssemblyCleanup");
    }
}
