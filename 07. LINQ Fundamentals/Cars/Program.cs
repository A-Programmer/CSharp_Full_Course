


using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cars;

class Program
{
    private static void CreateXml()
    {
        var records = ProcessCars("fuel.csv");
        XNamespace ns = "https://sadin.ir/cars/2016";
        XNamespace ex = "https://sadin.ir/cars/2016/ex";
        XDocument document = new();
        XElement cars = new XElement(ns + "Cars",
                from record in records
                select new XElement(ex + "Car", 
                                new XAttribute("Name", record.Name),
                                new XAttribute("Combined", record.Combined),
                                new XAttribute("Manufacturer", record.Manufacturer))
        );
        cars.Add(new XAttribute(XNamespace.Xmlns + "ex", ex));
        document.Add(cars);
        document.Save("fuel.xml");
    }
    private static void QueryXml()
    {
        
        XNamespace ns = "https://sadin.ir/cars/2016";
        XNamespace ex = "https://sadin.ir/cars/2016/ex";

        var document = XDocument.Load("fuel.xml");
        var query =
            from element in document.Element(ns + "Cars")?.Elements(ex + "Car")
                                                        ?? Enumerable.Empty<XElement>()
            // from element in document.Descendants("Car")
            where element.Attribute("Manufacturer")?.Value == "BMW"
            select element.Attribute("Name")?.Value;
        foreach (var name in query)
        {
            System.Console.WriteLine(name);
        }
    }
    
    private static void InsertData(CarDb db)
    {
        var cars = ProcessCars("fuel.csv");

        db.Database.Migrate();
        
        if(!db.Cars.Any())
        {
            foreach(var car in cars)
            {
                db.Cars.Add(car);
            }
            db.SaveChanges();
        }

    }
    private static void QueryData(CarDb db)
    {
        // var query =
        //     db.Cars.Where(c => c.Manufacturer == "BMW")
        //             .OrderByDescending(c => c.Combined)
        //             .ThenBy(c => c.Name)
        //             .Take(10);
        var query =
            db.Cars.GroupBy(c => c.Manufacturer)
                .Select(g => new 
                {
                    Name = g.Key,
                    Cars = g.OrderByDescending(c => c.Combined).Take(2)
                });
        foreach (var group in query)
        {
            System.Console.WriteLine(group.Name);
            foreach (var car in group.Cars)
            {
                System.Console.WriteLine($"\t{car.Name} : {car.Combined}");
            }
        }

        // foreach (var car in query)
        // {
        //     System.Console.WriteLine($"{car.Name} : {car.Combined}");
        // }
    }
    static void Main(string[] args)
    {

        string connectionString = 
            @"Server=.;Database=Cars;User Id=sa;Password=Manager2017;
            TrustServerCertificate=true;";
        var services = new ServiceCollection();

        services.AddDbContext<CarDb>(options =>
            options.UseSqlServer(connectionString));

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        var db = serviceProvider.GetService<CarDb>();
            
        // CreateXml();
        // QueryXml();
        
        InsertData(db);
        QueryData(db);

        // List<Car> cars = ProcessCars("fuel.csv");
        // List<Manufacturer> manufacturers = ProcessManufacturers("manufacturers.csv");

        
        // var query = cars.OrderByDescending(c => c.Combined)
        //                     .ThenBy(c => c.Name);
        
        // var query = 
        //             from car in cars
        //             orderby car.Combined descending, car.Name ascending
        //             select car;
        
        // var query = File.ReadAllLines("fuel.csv")
        //             .Skip(1)
        //             .Where(l => l.Length > 1)
        //             .ToCar();

        // var query =
        //             from car in cars
        //             join manufacturer in manufacturers
        //                 on car.Manufacturer equals manufacturer.Name
        //             orderby car.Combined descending, car.Name
        //             select new
        //             {
        //                 manufacturer.Headquartets,
        //                 car.Name,
        //                 car.Combined
        //             };

        // var query =
        //             cars.Join(manufacturers, c => c.Manufacturer,
        //                     m => m.Name, (c, m) => new {
        //                         m.Headquartets,
        //                         c.Name,
        //                         c.Combined
        //                     })
        //                 .OrderByDescending(c => c.Combined)
        //                 .ThenBy(c => c.Name);

        // var query =
        //             from car in cars
        //             join manufacturer in manufacturers
        //                 on new { car.Manufacturer, car.Year }
        //                     equals
        //                     new { Manufacturer = manufacturer.Name, manufacturer.Year }
        //             orderby car.Combined descending, car.Name ascending
        //             select new
        //             {
        //                 manufacturer.Headquartets,
        //                 car.Name,
        //                 car.Combined
        //             };
        

        // var query =
        //             cars.Join(manufacturers,
        //                     c => new { c.Year, c.Manufacturer },
        //                     m => new { m.Year, Manufacturer = m.Name },
        //                     (c, m) => new {
        //                         m.Headquartets,
        //                         c.Name,
        //                         c.Combined
        //                     })
        //                 .OrderByDescending(c => c.Combined)
        //                 .ThenBy(c => c.Name);

        // var query =
        //         from car in cars
        //         group car by car.Manufacturer.ToUpper() into manufacturer
        //         orderby manufacturer.Key
        //         select manufacturer;
        // var query =
        //         cars.GroupBy(c => c.Manufacturer)
        //             .OrderBy(g => g.Key);
        // foreach (var group in query)
        // {
        //     System.Console.WriteLine($"{group.Key} : {group.Count()}");
        //     foreach (var car in group.Take(2))
        //     {
        //         System.Console.WriteLine($"\t{car.Name} : {car.Combined}");
        //     }
        // }

        // var query =
        //     from manufacturer in manufacturers
        //     join car in cars on manufacturer.Name equals car.Manufacturer
        //         into carGroup
        //     select new
        //     {
        //         Manufacturer = manufacturer,
        //         Cars = carGroup
        //     };
        // var query =
        //     manufacturers.GroupJoin(cars,
        //                             m => m.Name,
        //                             c => c.Manufacturer,
        //                             (m, g) => new
        //                             {
        //                                 Manufacturer = m,
        //                                 Cars = g
        //                             })
        //                     .OrderBy(m => m.Manufacturer.Name);
        // foreach(var manufacturer in query)
        // {
        //     System.Console.WriteLine($"{manufacturer.Manufacturer.Name} : {manufacturer.Manufacturer.Headquartets}");
        //     foreach (var car in manufacturer.Cars)
        //     {
        //         System.Console.WriteLine($"\t{car.Name} : {car.Combined}");
        //     }
        // }

        // var query =
        //         from manufacturer in manufacturers
        //         join car in cars
        //             on manufacturer.Name equals car.Manufacturer
        //             into carGroup
        //         select new
        //         {
        //             Manufacturer = manufacturer,
        //             Cars = carGroup
        //         } into result
        //         group result by result.Manufacturer.Headquartets;
        // var query =
        //     manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer,
        //         (m, g) =>
        //         new
        //         {
        //             Manufacturer = m,
        //             Cars = g
        //         })
        //     .GroupBy(m => m.Manufacturer.Headquartets);
        // foreach(var group in query)
        // {
        //     System.Console.WriteLine($"{group.Key}");
        //     foreach (var car in group.SelectMany(g => g.Cars)
        //                             .OrderByDescending(c => c.Combined)
        //                             .Take(3))
        //     {
        //         System.Console.WriteLine($"\t{car.Name} : {car.Combined}");
        //     }
        // }

        // var query =
        //     from car in cars
        //     group car by car.Manufacturer into carGroup
        //     select new
        //     {
        //         Name = carGroup.Key,
        //         Max = carGroup.Max(c => c.Combined),
        //         Min = carGroup.Min(c => c.Combined),
        //         Avg = carGroup.Average(c => c.Combined),
        //     } into result
        //     orderby result.Max descending
        //     select result;
        // var query =
        //         cars.GroupBy(c => c.Manufacturer)
        //         .Select(g =>
        //         {
        //             var result = g.Aggregate(new CarStatistics(),
        //                             (acc, c) => acc.Accumulate(c),
        //                             acc => acc.Compute());
        //             return new 
        //             {
        //                 Name = g.Key,
        //                 Avg = result.Average,
        //                 Max = result.Max,
        //                 Min = result.Min
        //             };
        //         });
        // foreach (var result in query)
        // {
        //     System.Console.WriteLine($"{result.Name}");
        //     System.Console.WriteLine($"\tMax: {result.Max}");
        //     System.Console.WriteLine($"\tMin: {result.Min}");
        //     System.Console.WriteLine($"\tAvg: {result.Avg}");
        // }

        

        // foreach (var car in query.Take(10))
        // {
        //     System.Console.WriteLine($"{car.Headquartets} : {car.Name} : {car.Combined}");
        // }
    }

    private static List<Manufacturer> ProcessManufacturers(string path)
    {
        var query =
                File.ReadAllLines(path)
                    .Where(l => l.Length > 1)
                    .Select(l =>
                    {
                        var columns = l.Split(',');
                        return new Manufacturer
                        {
                            Name = columns[0],
                            Headquartets = columns[1],
                            Year = int.Parse(columns[2])
                        };
                    });

        return query.ToList();
    }

    private static List<Car> ProcessCars(string path)
    {
        // return File.ReadAllLines(path)
        //         .Skip(1)
        //         .Where(line => line.Length > 1)
        //         .Select(Car.ParseFromCsv)
        //         .ToList();
        var query =
            from line in File.ReadAllLines(path).Skip(1)
            where line.Length > 1
            select Car.ParseFromCsv(line);

        return query.ToList();
    }
}

public class CarStatistics
{
    public int Max { get; set; }
    public int Min { get; set; }
    public int Total { get; set; }
    public int Count { get; set; }
    public double Average { get; set; }

    public CarStatistics()
    {
        Max = Int32.MinValue;
        Min = Int32.MaxValue;
    }
    public CarStatistics Accumulate(Car car)
    {
        Count++;
        Total += car.Combined;
        Max = Math.Max(Max, car.Combined);
        Min = Math.Min(Min, car.Combined);


        return this;
    }

    public CarStatistics Compute()
    {
        Average = Total / Count;
        return this;
    }
}

public static class CarExtensions
{
    public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            string[] columns = line.Split(',');

            yield return new Car
            {
                Year = int.Parse(columns[0]),
                Manufacturer = columns[1],
                Name = columns[2],
                Displacement = double.Parse(columns[3]),
                Cylinders = int.Parse(columns[4]),
                City = int.Parse(columns[5]),
                Highway = int.Parse(columns[6]),
                Combined = int.Parse(columns[7])
            };
        }
    }
}