
using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {

        public Book(string name)
        {
            this.name = name;
            //Any codes
            grades = new List<double>();
        }


        public void AddGrade(double grade)
        {
            if(grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
        }

        public void ShowStats()
        {
            double result = 0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach(var grade in grades)
            {
                highGrade = Math.Max(highGrade, grade);
                lowGrade = Math.Min(lowGrade, grade);
                result += grade;
            }
            result /= grades.Count;
            Console.WriteLine($"The highest grade is {highGrade}");
            Console.WriteLine($"The lowest grade is {lowGrade}");
            Console.WriteLine($"The average is {result:N2}");
        }



        private List<double> grades;
        private string name;
    }
}
