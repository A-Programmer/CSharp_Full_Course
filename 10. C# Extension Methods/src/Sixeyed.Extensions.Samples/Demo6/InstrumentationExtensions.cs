using System.Diagnostics;
using System.Reflection;

namespace Sixeyed.Extensions.Samples.Demo6;

public static class InstrumentationExtensions
{
    private static Dictionary<Guid, Stopwatch> _stopWatches = new();
    public static double GetPreciseElapsedTime(this Instrumentation instrumentation)
    {
        var fieldInfo = typeof(Instrumentation).GetField("_startedAt", BindingFlags.Instance | BindingFlags.NonPublic);
        var startedAt = (DateTime)fieldInfo.GetValue(instrumentation);
        return new TimeSpan(DateTime.Now.Ticks - startedAt.Ticks).TotalSeconds;
    }

    public static void StartWithPrecision(this Instrumentation instrumentation)
    {
        _stopWatches[instrumentation.Id] = Stopwatch.StartNew();
    }

    public static long GetReallyPreciseElapsedTime(this Instrumentation instrumentation)
    {
        return _stopWatches[instrumentation.Id].ElapsedMilliseconds;
    }
}
