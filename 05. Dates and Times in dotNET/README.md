# Dates and Times in .NET

DateTime.Parse() parses an string to a date time format. `DateTime.Parse("9/2/2019")`

We can specify the culture to convert string to user specific date time zone:

`DateTime.Parse("9/2/2019", CultureInfo.GetCultureInfo("en-GB")))`

9 is month or 2? This is different in different cultures, by specifying CultureInfo we can set which culture we meant. This is called date ambiguity.

**Date ambiguity is solved with ISO 8601:**

`2019-06-10T18:00:00+00:00`

Year - Month - Day - Divider - Hour : Minute : Second + Time zone offset or Zulu time (Z)

If we want to get the time or set the time hard coded it's better to use DateTime.UtcNow instead of DateTime.Now because while we are using UTC (Universal time) we are not dealing with Time Zones and DateTime.Now returns different results based on computer that we are running this command.

But sometimes we need to read dates and times from a file or user should enter the date, how about this? In this case we can use TimeZoneInfo to get the time zones or convert dates into another time zone:

```csharp
class Program
{
    static void Main(string[] args)
    {
        DateTime now = DateTime.Now;
        TimeZoneInfo sydneyTimeZone 
            = TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time");
        DateTime sydneyTime = TimeZoneInfo.ConvertTime(now, sydneyTimeZone);
  
        Console.WriteLine($"My local time: {now}");
        Console.WriteLine($"Sydney time: {sydneyTime}");
    }
}
```

As we learned, DateTime has no time zone and it is based on the computer, but fortunately, there is another type called DateTimeOffset which is like DateTime with the addition of providing us with information about the time zone.

```csharp
Console.WriteLine(DateTime.Now);
Console.WriteLine(DateTimeOffset.Now);
```

When we use DateTime.Parse method it works fine but when the given string includes the time zone like `2019-07-01 10:00:00 PM +02:00`  the Parse method does not pay attention to the time zone (+02:00). Here we can use DateTimeOffset but if we could not use DateTimeOffset, we can parse the string into the UTC with this settings:

```csharp
string stringDate = "2019-07-01 10:00:00 PM +02:00";
        DateTime parsedDate = DateTime.Parse(stringDate,
            CultureInfo.InvariantCulture,
            DateTimeStyles.AdjustToUniversal);
Console.WriteLine(parsedDate);
        Console.WriteLine(parsedDate.Kind);
```

There is another method called ParseExact which we should pass the string date, the format of string and lastly pass the culture information:

```csharp
string stringDate = "9/10/2019 10:00:00 PM";
        DateTime parsedDate = DateTime.ParseExact(stringDate, "M/d/yyyy hh:mm:ss tt",
            CultureInfo.InstalledUICulture);
Console.WriteLine(parsedDate);
```

By using .ToString("") we can specify to show date time in which format, and for converting to ISO 8601 we can use o : `.ToString("o")`

In most cases it's better to use Utc to store the date time and when we want to convert Utc to local time, there is method called `.ToLocalTime()`

# Date and Time Arithmetic

TimeSpan shows the time differences.

We can create a time span by using TimeSpan type and specify set up it by using its constructor:

```csharp
TimeSpan timeSpan = new(60, 100, 200);
```

What will display in the screen if we type `Console.WriteLine(timeSpan.Hours);` ?

We passed 60 as hours, 100 as minutes and 200 as seconds, so by running that command do we get the 60 on the screen? (60 hours + 100 minutes + 200 seconds = 2 days 13 hours 43 minutes 20 seconds, so we should get 61?)

Actually, we will see 13, but how? becuase in this case we have 2 days and 13 hours more, so by calling Hours we will get the hours of this span, if we need to get days, hours, minutes, seconds we should call each of them and if we want to see total hours we should call TotalHours method.

```csharp
TimeSpan timeSpan = new(60, 100, 200);
Console.WriteLine(timeSpan.Days); // 2
Console.WriteLine(timeSpan.Hours); // 13
Console.WriteLine(timeSpan.Minutes); // 43
Console.WriteLine(timeSpan.Seconds); // 20
Console.WriteLine(timeSpan.TotalHours); // 61.72222222222222
```

TimSpan automatically calculates the correct amount of days, hours, minutes, seconds, milliseconds and ticks based on the data its being created with.

TimeSpan allows us to get the representations as different things such as days, hours, minutes, seconds and milliseconds. So that is extremely powerful. Now the reason that we have TimeSpan is because we need a way for us to represent an interval of a time, especially when we are comparing two dates to each other.

By creating Calendar object we can access to a lot of methods to work with weeks and week days and some other information about dates:

```csharp
static Calendar calendar = CultureInfo.InvariantCulture.Calendar;
```

Also, if we need to work with ISO 8601 we can use ISOWeek:

```csharp
Console.WriteLine(ISOWeek.GetWeekOfYear(DateTime.UtcNow));
```
