using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Erdi's book of wonder");
            book.AddGrade(89.1);
            book.AddGrade (90.5);
            book.AddGrade(100);

            var stats = book.GetStatistics();

            Console.WriteLine($"Highest Grade {stats.High:N1}");
            Console.WriteLine($"Lowest Grade {stats.Low:N1}");
            Console.WriteLine($"Average is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
