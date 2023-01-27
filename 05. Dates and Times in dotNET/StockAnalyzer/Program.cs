using System.Globalization;

namespace StockAnalyzer;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting application ...");
        string[] lines = File.ReadAllLines(@"./StockData.csv");

        foreach (string line in lines.Skip(1))
        {
            string[] segments = line.Split(',');
            DateTime targetDate = DateTime.Parse(segments[1], CultureInfo.GetCultureInfo("en-GB"));
            Console.WriteLine($"{targetDate.ToLongDateString()}");
        }

        Console.WriteLine("=============");

        DateTime now = DateTime.Now;
        TimeZoneInfo sydneyTimeZone 
            = TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time");
        DateTime sydneyTime = TimeZoneInfo.ConvertTime(now, sydneyTimeZone);
        
        Console.WriteLine($"My local time: {now}");
        Console.WriteLine($"Sydney time: {sydneyTime}");

        Console.WriteLine("=============");

        Console.WriteLine(DateTime.Now);
        Console.WriteLine(DateTimeOffset.Now);

        Console.WriteLine("=============");

        DateTimeOffset time = DateTimeOffset.Now.ToOffset(TimeSpan.FromHours(-10));

        foreach (TimeZoneInfo timeZone in TimeZoneInfo.GetSystemTimeZones())
        {
            if(timeZone.GetUtcOffset(time) == time.Offset)
            {
                Console.WriteLine(timeZone);
            }
        }

        Console.WriteLine("=============");

        string stringDate = "2019-07-01 10:00:00 PM +02:00";
        DateTime parsedDate = DateTime.Parse(stringDate,
            CultureInfo.InvariantCulture,
            DateTimeStyles.AdjustToUniversal);
        Console.WriteLine(parsedDate);
        Console.WriteLine(parsedDate.Kind);
        // DateTime parsedDate = DateTime.ParseExact(stringDate, 
        //     "M/d/yyyy hh:mm:ss tt", CultureInfo.InstalledUICulture);

        Console.WriteLine("=============");

        string simpleDateString = "9/10/2019 10:00:00 PM";
        DateTime parsedSimpleDate = DateTime.ParseExact(simpleDateString,
            "M/d/yyyy h:mm:ss tt",
            CultureInfo.InvariantCulture);
        Console.WriteLine(parsedSimpleDate.ToString("o"));
        
    }
}