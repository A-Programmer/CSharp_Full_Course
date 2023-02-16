namespace DelegatesAndEvents;

public class ProcessData
{
    public void Process(int x, int y, BizRuleDelegate del)
    {
        int result = del(x, y);
        System.Console.WriteLine($"Result for {x} and {y} is {result}");
    }
    public void ProcessAction(int x, int y, Action<int, int> action)
    {
        action(x, y);
        System.Console.WriteLine("Action has been processed");
    }
    public void ProcessFunc(int x, int y, Func<int, int, int> func)
    {
        var result = func(x, y);
        System.Console.WriteLine($"Func has been processed with result: {result}");
    }
}