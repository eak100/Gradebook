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

            //book.ShowStatistics();
            var stats = book.GetStatistics();

            Console.WriteLine($"Highest Grade: {stats.High:N1}");
            Console.WriteLine($"Lowest Grade: {stats.Low:N1}");
            Console.WriteLine($"Average is :{stats.Average:N1}");

            //var numbers= new []{ 1.1,2.2,3.3,4.4,5.5};
            /*var grades=new List<double>(){1.1,2.2,3.3,4.4,5.5};
            grades.Add(26.3);
        */
        /*
            var result=0.0;
            var highGrade = double.MinValue;
            var lowGrade= double.MaxValue;
            foreach(var number in grades)
            {
                //Get the highest grade 
                //approach 1
                // if(number> highGrade){
                //     highGrade = number;
                // }
                //approach2
                highGrade= Math.Max(number, highGrade);
                lowGrade=Math.Min(number, lowGrade);
                result+=number;

            }
            result/=grades.Count;

            Console.WriteLine($"Highest Grade: {highGrade:N1}");
            Console.WriteLine($"Lowest Grade: {lowGrade:N1}");
            Console.WriteLine($"Average is :{result:N1}");


            */
        }
    }
}
