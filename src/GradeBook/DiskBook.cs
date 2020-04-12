using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string Name) : base(Name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                    GradeAdded(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    result.Add(double.Parse(line));
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}