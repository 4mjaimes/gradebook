using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class InMemoryBook : Book, IBook
    {
        public InMemoryBook(string Name) : base(Name)
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
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
                throw new ArgumentException($"Invalid {nameof(grade)}");
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            Grades.ForEach(g => result.Add(g));
            return result;
        }

        public override event GradeAddedDelegate GradeAdded;
        private List<double> Grades;
    }
}