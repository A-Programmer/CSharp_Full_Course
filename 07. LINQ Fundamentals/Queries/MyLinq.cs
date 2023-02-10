namespace Queries;

public static class MyLinq
{
    public static IEnumerable<double> Random()
    {
        Random random = new();
        while(true)
        {
            yield return random.NextDouble();
        }
    }
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (T item in source)
        {
            if(predicate(item))
            {
                yield return item;
            }
        }
    }
}