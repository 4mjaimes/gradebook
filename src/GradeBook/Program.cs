using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Manuel Jaimes");

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
            var statistics = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {statistics.Low}");
            Console.WriteLine($"The highest grade is {statistics.High}");
            Console.WriteLine($"The average grade is {statistics.Average:N1}");
            Console.WriteLine($"The letter grade is {statistics.Letter}");
        }
    }
}
