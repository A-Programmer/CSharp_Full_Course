namespace AsynchronousInDotNet;

public class AsyncJobs
{
    public async Task ProcessFile(IProgress<IEnumerable<string>> progess = null)
    {
        var loadLinesTask = Task.Run(/*async */() =>
        {
            var lines = File.ReadAllLines("fuel.csv");
            // var lines = await File.ReadAllLinesAsync("fuel.csv");
            return lines;
        });

        await loadLinesTask.ContinueWith(t =>
        {
            var lines = t.Result;
            List<string> newLines = new();
            foreach (var line in lines.Skip(0))
            {
                newLines.Add(line);
                // Console.WriteLine(line);
                progess?.Report(t.Result);
            }
        }, TaskContinuationOptions.OnlyOnRanToCompletion);

        await loadLinesTask.ContinueWith(t =>
        {
            Console.WriteLine($"\n\n An error occured: {t.Exception.Message} \n\n");
        }, TaskContinuationOptions.OnlyOnFaulted);
    }

    public Task<IEnumerable<int>> ProcessFile_V2()
    {
        TaskCompletionSource<IEnumerable<int>> source = new();
        ThreadPool.QueueUserWorkItem(async _ =>
        {
            List<int> years = new();
            try
            {
                var lines = File.ReadAllLines("fuel.csv");
                foreach (string line in lines.Skip(1))
                {
                    years.Add(int.Parse(line.Split(',')[0]));
                }
                source.SetResult(years);
            }
            catch(Exception ex)
            {
                source.SetException(ex);
            }
        });

        return source.Task;
    }

    public async IAsyncEnumerable<int> ProcessFile_V3()
    {
        using var stream = new StreamReader("fuel.csv");
        await stream.ReadLineAsync();

        string line;
        while((line = await stream.ReadLineAsync()) != null)
        {
            var segments = line.Split(',');
            var year = int.Parse(segments[0]);

            yield return year;
            await Task.Delay(200);
        }
    }
}
