using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Erdi's book of wonder");

            while(true)
            {
                Console.WriteLine($"Please enter a grade. Press q to quit: ");
                var input = Console.ReadLine();
            
                if(input == "q")
                {
                    break;
                }

                var grade = double.Parse(input); // converts string input to double
                book.AddGrade(grade);
                
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"Highest Grade {stats.High:N1}");
            Console.WriteLine($"Lowest Grade {stats.Low:N1}");
            Console.WriteLine($"Average is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
