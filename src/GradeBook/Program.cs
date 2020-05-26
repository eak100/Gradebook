using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Erdi's book of wonder");
            book.GradeAdded += OnGradeAdded;
            /* // Since the event we created is a multi cast delegate we can create more than one without a problem.
             book.GradeAdded += OnGradeAdded;
             book.GradeAdded -= OnGradeAdded; 
             //It is also legal to subtract a delegate.
             book.GradeAdded += OnGradeAdded;
             */

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"Highest Grade {stats.High:N1}");
            Console.WriteLine($"Lowest Grade {stats.Low:N1}");
            Console.WriteLine($"Average is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(Book book)
        {
            
            while (true)
            {
                Console.WriteLine($"Please enter a grade. Press q to quit: ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input); // converts string input to double
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)// Catches only argument error
                {
                    Console.WriteLine(ex.Message);
                    //Message shows you the detail of the error  
                }
                catch (FormatException ex)// Catches only format error. 
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
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
