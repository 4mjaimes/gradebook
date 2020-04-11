using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public Book(string Name)
        {
            Grades = new List<double>();
            this.Name = Name;
        }
        public void AddGrade(char letter)
        {
            switch (letter)
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
        }
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
                throw new ArgumentException($"Invalid {nameof(grade)}");
        }
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            Grades.ForEach(g =>
            {
                result.Low = Math.Min(result.Low, g);
                result.High = Math.Max(result.High, g);
                result.Average += g;
            });

            result.Average /= Grades.Count;

            switch (result.Average)
            {
                case var letter when letter >= 90.0:
                    result.Letter = 'A';
                    break;
                case var letter when letter >= 80.0:
                    result.Letter = 'B';
                    break;
                case var letter when letter >= 70.0:
                    result.Letter = 'C';
                    break;
                case var letter when letter >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }

        public event GradeAddedDelegate GradeAdded;
        private List<double> Grades;
        public string Name { get; set; }
    }
}