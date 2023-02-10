using System;

namespace Feature;

class Program
{
    static void Main(string[] args)
    {
        Func<int, int> square = x => x * x;
        System.Console.WriteLine(square(4));

        Func<int, int, int> add = (x, y) => x + y;
        System.Console.WriteLine(add(3, 5));

        Func<int, int, int> add_v2 = (x , y) =>
        {
            int temp = x + y;
            return temp;
        };

        Action<int> write = x => System.Console.WriteLine(x);

        IEnumerable<Employee> developers = new Employee[]
        {
            new Employee { Id = 1, Name = "Kamran" },
            new Employee { Id = 1, Name = "John" }
        };

        IEnumerable<Employee> sales = new List<Employee>()
        {
            new Employee { Id = 1, Name = "Alex" }
        };

        IEnumerator<Employee> enumerator = developers.GetEnumerator();
        while(enumerator.MoveNext())
        {
            System.Console.WriteLine(enumerator.Current.Name);
        }

        // developers.Where(delegate(Employee e) { return e.Name.StartsWith("K"); });
        // developers.Where(NameStartWithK);
        developers.Where(delegate (Employee employee)
            {
                return employee.Name.StartsWith("K");
            });
    }
    private static bool NameStartWithK(Employee employee)
    {
        return employee.Name.StartsWith("K");
    }
}