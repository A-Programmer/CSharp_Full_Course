using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book1 = new DiskBook("Kamran Sadin");
            book1.GradeAdded += OnGradeAdded;

            EnteringGrades(book1);

            var stats = book1.GetStats();

            Console.WriteLine($"The book name is {book1.Name}");

            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The average is {stats.Average:N2}");
            Console.WriteLine($"The letter is {stats.Letter}");
        }

        private static void EnteringGrades(IBook book1)
        {
            while (true)
            {
                Console.WriteLine("Please enter a grade or 'q' to quit:");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book1.AddGrade(grade);
                    book1.AddGrade('F');
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //..
                }



            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade added to book1");
        }
    }
}
