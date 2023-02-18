using Newtonsoft.Json;

namespace Sixeyed.Extensions.Samples.Demo5;

public static class ObjectExtensions
{
    public static string ToJsonString(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static string GetJsonTypeDescription(this object obj)
    {
        var description = obj.GetType().GetDescription();
        return description.ToJsonString();
    }
}
