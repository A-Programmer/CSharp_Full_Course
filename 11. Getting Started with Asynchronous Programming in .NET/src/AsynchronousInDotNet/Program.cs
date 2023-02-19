using System.Collections.Concurrent;

namespace AsynchronousInDotNet;

public class Program
{
    public async static Task Main(string[] args)
    {


        var asyncJobs = new AsyncJobs();
        await foreach (var year in asyncJobs.ProcessFile_V3())
        {
            System.Console.WriteLine(year);
        }


        Console.WriteLine("Starting ...");
        await Task.Factory.StartNew(() =>
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                System.Console.WriteLine("Completing 1");
            }, TaskCreationOptions.AttachedToParent);
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                System.Console.WriteLine("Completing 2");
            }, TaskCreationOptions.AttachedToParent);
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                System.Console.WriteLine("Completing 3");
            }, TaskCreationOptions.AttachedToParent);
        }, TaskCreationOptions.DenyChildAttach);
        System.Console.WriteLine("Completed");

        Progress<IEnumerable<string>> progress = new();
        progress.ProgressChanged += (_, e) =>
        {
            Console.WriteLine("New item added");
        };

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
        // await asyncJobs.ProcessFile(progress);

        var years = await asyncJobs.ProcessFile_V2();
        Console.WriteLine(years.Count());


        Console.ReadKey();
    }
}