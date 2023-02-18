using System.Collections.Concurrent;

namespace AsynchronousInDotNet;

public class Program
{
    public async static Task Main(string[] args)
    {
        List<string> result = new() { "Started ..." };

        await Task.Run(() => 
        {
            result.Add("In the async job");
        });
        // Thread.Sleep(1000);
        foreach (string res in result)
        {
            Console.WriteLine(res);
        }

        var asyncJobs = new AsyncJobs();
        await asyncJobs.ProcessFile();
    }
}