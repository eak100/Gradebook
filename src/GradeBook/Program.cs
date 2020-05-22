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

                try
                {
                    var grade = double.Parse(input); // converts string input to double
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)// Catches only argument error
                {
                    Console.WriteLine(ex.Message);
                     //Message shows you the detail of the error  
                }
                catch(FormatException ex)// Catches only format error. 
                {
                    Console.WriteLine(ex.Message);
                }
                /*Using different catch is better instead of using catching all exceptions since you will know the exact type of error*/
                finally
                {
                    /* the piece of code that will always be executed */
                    Console.WriteLine("***");
                    /*Finally  is generally used to close a file, clear the execution  etc. */
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"Highest Grade {stats.High:N1}");
            Console.WriteLine($"Lowest Grade {stats.Low:N1}");
            Console.WriteLine($"Average is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
