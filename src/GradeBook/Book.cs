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
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            Grades.ForEach( g => {
                result.Low = Math.Min(result.Low, g);
                result.High = Math.Max(result.High, g);
                result.Average += g;
             });

            result.Average /= Grades.Count;
            
            return result;
        }

        private List<double> Grades;
        private string Name;

    }
}