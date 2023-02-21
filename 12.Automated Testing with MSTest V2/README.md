# Automated Testing with MSTest V2

**The benefits of automated tests:**  
- Find (and fix) errors sooner
- Free to execute as often as required
- Quick to execute (versus manual testing)
- Generally more repeatable (versus manual)
- Execution flexibility:
  - Run on demand
  - As part of continous integration
  - On a schedule (e.g. overnight)
- Happier:
  - Developers & teams
  - Happier end users
  - Happier business owners  

 If you are using command line to run tests, you can use [test filters](https://github.com/Microsoft/vstest-docs/blob/main/docs/filter.md)  

 Also, if you want to see the output you can add `-v n` to the end of `dotnet test` command :   
 `dotnet test --filter"ClassName=GameEngine.Tests.EnemyFactoryShould" -v n`  

By using `[TestInitialize]` attribute, we can run that method **befor** starting each test.  

By using `[TestCleanup]` attribute, we can run that method **after** starting each test.  

By using `[ClassInitialize]` attribute, we can run that method **before** starting the first test. Actually, it is going to start once for class at the initialization time.  
But this method should be static and we need to pass TestContext to it:  

```csharp
[ClassInitialize]
    public static void LifecycleClassInit(TestContext context)
    {
        Console.WriteLine("Class Initialization ...");
    }
```  

Also, for cleaning up the class we can use ClassCleanup attribute which it will run after all test methods:  

```csharp
[ClassCleanup]
    public static void LifecycleClassCleanup()
    {
        Console.WriteLine("Class Cleanup ...");
    }
```

There are same attributes called `[AssemblyInitialize]` and `[AssemblyCleanup]` that will run before and after tests of an assembly.  

```csharp
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
```

