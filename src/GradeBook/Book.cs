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
            grades.Add(grade);


        }


        // List<double> grades= new List<double>();  Another way is to write a constructor
        // var doesn't work for fields! you can use this for everywhere within Book now

        public Statistics GetStatistics(){ 

            var result= new Statistics();
            result.Average=0.0;
            result.High=double.MinValue;
            result.Low=double.MaxValue;

            foreach(var number in grades)
            {

                result.High= Math.Max(number, result.High);
                result.Low=Math.Min(number, result.Low);  
                result.Average+=number;

            }
            result.Average/=grades.Count;


            return result;
        }
        private List<double> grades;

        public string Name;

        // if it's private it can only be used within the class that is defined
    }


}