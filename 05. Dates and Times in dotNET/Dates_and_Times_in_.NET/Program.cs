using System.Globalization;

namespace Dates_and_Times_in_.NET;

class Program
{
    static Calendar calendar = CultureInfo.InvariantCulture.Calendar;
    static void Main(string[] args)
    {
        TimeSpan timeSpan = new(60, 100, 200);
        Console.WriteLine(timeSpan.Days);
        Console.WriteLine(timeSpan.Hours);
        Console.WriteLine(timeSpan.Minutes);
        Console.WriteLine(timeSpan.Seconds);
        Console.WriteLine(timeSpan.TotalHours);

        Console.WriteLine("==============");

        DateTimeOffset start = DateTimeOffset.UtcNow;
        // The following code will be a bit different in ticks,
        // because the start and end are not runing in one moment,
        // the end command will runn one tick after start,
        // for solving this problem we can use start.AddSecond(45) for the end value.
        // DateTimeOffset end = DateTimeOffset.UtcNow.AddSeconds(45);
        DateTimeOffset end = start.AddSeconds(45);

        TimeSpan difference = end - start;

        Console.WriteLine(difference.Seconds);

        Console.WriteLine(ISOWeek.GetWeekOfYear(DateTime.UtcNow));

    }
}