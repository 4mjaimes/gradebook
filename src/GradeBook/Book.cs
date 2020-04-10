using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string Name)
        {
            Grades = new List<double>();
            this.Name = Name;
        }
        public void AddGrade(double grade)
        {
            Grades.Add(grade);
        }
        public void ShowStatistics()
        {
            var result = 0.0;
            var minValue = double.MaxValue;
            var maxValue = double.MinValue;
            foreach (var number in Grades)
            {
                minValue = Math.Min(minValue, number);
                maxValue = Math.Max(maxValue, number);
                result += number;
            }

            result /= Grades.Count;

            Console.WriteLine($"The average grade is {result:N1}");
            Console.WriteLine($"The min value is {minValue}");
            Console.WriteLine($"The max value is {maxValue}");
        }

        private List<double> Grades;
        private string Name;

    }
}