using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Manuel Jaimes");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);
            var statistics = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {statistics.Low}");
            Console.WriteLine($"The highest grade is {statistics.High}");
            Console.WriteLine($"The average grade is {statistics.Average:N1}");
            Console.WriteLine($"The letter grade is {statistics.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'Q' o quit");
                var input = Console.ReadLine();

                if (input.Equals("Q"))
                    break;
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was adedd");
        }
    }
}
