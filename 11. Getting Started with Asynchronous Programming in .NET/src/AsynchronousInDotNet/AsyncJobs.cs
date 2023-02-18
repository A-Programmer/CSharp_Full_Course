namespace AsynchronousInDotNet;

public class AsyncJobs
{
    public async Task ProcessFile()
    {
        var loadLinesTask = Task.Run(/*async */() =>
        {
            var lines = File.ReadAllLines("fusel.csv");
            // var lines = await File.ReadAllLinesAsync("fuel.csv");
            return lines;
        });

        loadLinesTask.ContinueWith(t =>
        {
            var lines = t.Result;

            foreach (var line in lines.Skip(1))
            {
                Console.WriteLine(line);
            }
        }, TaskContinuationOptions.OnlyOnRanToCompletion);

        await loadLinesTask.ContinueWith(t =>
        {
            Console.WriteLine($"\n\n An error occured: {t.Exception.Message} \n\n");
        }, TaskContinuationOptions.OnlyOnFaulted);
    }
}
