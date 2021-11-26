using System;

namespace NthDay
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "----",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            Console.WriteLine("\nBefore:");
            foreach (var item in daysOfWeek)
                Console.WriteLine(item);

            daysOfWeek[2] = "Wednesday";

            Console.WriteLine("\n\nAfter:");
            foreach (var item in daysOfWeek)
                Console.WriteLine(item);


        }
    }
}
