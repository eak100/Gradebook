using System;
using System.Collections.Generic;

namespace GradeBook
{


    public class Book  
    {        
        public Book(string name)//Constructor has to have a same name with class
        {
            grades=new List<double>();
            //this.name=name; j 
            this.Name=name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);


        }


        // List<double> grades= new List<double>();  Another way is to write a constructor
        // var doesn't work for fields! you can use this for everywhere within Book now

        public Statistics GetStatistics(){ //returns class Statistics

            var result= new Statistics();
            result.Average=0.0;
            result.High=double.MinValue;
            result.Low=double.MaxValue;
            //var result=0.0;
            //var highGrade = double.MinValue;
            // lowGrade= double.MaxValue;
            foreach(var number in grades)
            {
                //Get the highest grade 
                //approach 1
                // if(number> highGrade){
                //     highGrade = number;
                // }
                //approach2

                /*
                highGrade= Math.Max(number, highGrade);
                lowGrade=Math.Min(number, lowGrade);
                result+=number;

            */
                result.High= Math.Max(number, result.High);
                result.Low=Math.Min(number, result.Low);  
                result.Average+=number;

            }
            result.Average/=grades.Count;
            /*
            Console.WriteLine($"Highest Grade: {highGrade:N1}");
            Console.WriteLine($"Lowest Grade: {lowGrade:N1}");
            Console.WriteLine($"Average is :{result:N1}");
            */

            return result;
        }
        private List<double> grades;
        //private string name; 
        public string Name;

        // if it's private it can only be used within the class that is defined
    }


}