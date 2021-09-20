using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>() {85.67, 89, 90, 79.25};
            grades.Add(97);
            grades.Add(68);

            double result = 0;
            foreach(var grade in grades)
            {
                result += grade;
            }
            result /= grades.Count;

            Console.WriteLine($"The average is {result:N2}");
        }
    }
}

//if
//list
//array
//var
//foreach
