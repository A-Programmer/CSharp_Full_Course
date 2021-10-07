using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Book book1 = new Book("Kamran Sadin");
            book1.AddGrade(89);
            book1.AddGrade(94.2);
            book1.AddGrade(89.12);
            book1.AddGrade(88.32);
            book1.AddGrade(89);
            
            var stats = book1.GetStats();

            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The average is {stats.Average:N2}");
        }
    }
}
