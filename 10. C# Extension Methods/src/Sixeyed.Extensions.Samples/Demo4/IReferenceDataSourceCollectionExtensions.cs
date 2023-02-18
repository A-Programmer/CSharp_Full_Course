using System.Collections;

namespace Sixeyed.Extensions.Samples.Demo3;

public static class IReferenceDataSourceCollectionExtensions
{
    // public static IEnumerable<ReferenceDataItem> GetAllItemsByCode(this IReferenceDataSource[] sources, string code)
    // {
    //     List<ReferenceDataItem> items = new();
    //     foreach (IReferenceDataSource source in sources)
    //     {
    //         items.AddRange(source.GetItemsByCode(code));
    //     }
    //     return items;
    // }
    public static IEnumerable<ReferenceDataItem> GetAllItemsByCode(this IEnumerable sources, string code)
    {
        List<ReferenceDataItem> items = new();
        foreach (var source in sources)
        {
            var refDataSource = source as IReferenceDataSource;
            if(refDataSource != null)
            {
                items.AddRange(refDataSource.GetItemsByCode(code));
            }
        }
        return items;
    }

    public static IEnumerable<ReferenceDataItem> GetAllItemsByCode(this IEnumerable<IReferenceDataSource> sources, string code)
    {
        return sources.SelectMany(x => x.GetItemsByCode(code));
    }
}
