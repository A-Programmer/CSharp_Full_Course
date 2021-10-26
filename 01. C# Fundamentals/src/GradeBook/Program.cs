using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Book book1 = new Book("Kamran Sadin");
            book1.GradeAdded += OnGradeAdded;

            
            while(true)
            {
                Console.WriteLine("Please enter a grade or 'q' to quit:");
                var input = Console.ReadLine();
                if(input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book1.AddGrade(grade);
                    book1.AddGrade('F');
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //..
                }


                
            }

            var stats = book1.GetStats();

            Console.WriteLine($"The book name is {book1.Name}");

            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The average is {stats.Average:N2}");
            Console.WriteLine($"The letter is {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade added to book1");
        }
    }
}
