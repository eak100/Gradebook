using System;
using System.Collections.Generic;

namespace GradeBook
{


    public class Book  
    {        
        public Book(string name)//Constructor has to have a same name with class
        {
            grades=new List<double>();
            Name=name; // C# now can differentiate between name and Name
        }
        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >=0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid Value.");
            }
        }


        // List<double> grades= new List<double>();  Another way is to write a constructor
        // var doesn't work for fields! you can use this for everywhere within Book now

        public Statistics GetStatistics(){ 

            var result= new Statistics();
            result.Average=0.0;
            result.High=double.MinValue;
            result.Low=double.MaxValue;

            
            for (var index = 0; index < grades.Count; index++)
            {
             /* for loop is done this way simple.. */
                result.High= Math.Max(grades[index], result.High);
                result.Low=Math.Min(grades[index], result.Low);  
                result.Average+=grades[index];
                index++;

            }
            result.Average/=grades.Count;


            return result;
        }
        private List<double> grades;

        public string Name;

        // if it's private it can only be used within the class that is defined
    }


}