
using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {

        public Book(string name)
        {
            Name = name;
            //Any codes
            grades = new List<double>();
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;
                
                case 'C':
                    AddGrade(70);
                    break;
                
                default:
                    AddGrade(0);
                    break;
            }
            //....
        }


        public void AddGrade(double grade)
        {
            if(grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public Stats GetStats()
        {
            var result = new Stats();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for(var index = 0; index < grades.Count; index += 1)
            {
                result.High = Math.Max(result.High, grades[index]);
                result.Low = Math.Min(result.Low, grades[index]);
                result.Average += grades[index];
            }
            result.Average /= grades.Count;
            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }



        private List<double> grades;
        public string Name;
    }
}
