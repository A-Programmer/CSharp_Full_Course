namespace Queries;

class Program
{
    static void Main(string[] args)
    {
        var numbers = MyLinq.Random().Where(n => n > 0.5).Take(10);
        foreach (var number in numbers)
        {
            System.Console.WriteLine(number);
        }
        List<Movie> movies = new()
        {
            new Movie { Title = "The Dark Knight", Rating = 8.9f, Year = 2008 },
            new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2010 },
            new Movie { Title = "Casablanca", Rating = 8.5f, Year = 1942 },
            new Movie { Title = "Start Wars V", Rating = 8.7f, Year = 1980 }
        };

        // IEnumerable<Movie> query = movies.Where(m => m.Year > 2000);
        // IEnumerable<Movie> query = movies.Filter(m => m.Year > 2000);
        List<Movie> query = movies.Where (m => m.Year > 2000).ToList();
        // foreach (Movie movie in query)
        // {
        //     Console.WriteLine(movie.Title);
        // }
        System.Console.WriteLine(query.Count);
        IEnumerator<Movie> enumerator = query.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current.Title);
        }
    }
}