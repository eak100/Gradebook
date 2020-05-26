using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args); //It is legal to define an empty delegate


    public class Book  
    {        
        public Book(string name)//Constructor has to have a same name with class
        {
            grades=new List<double>();
            Name=name; // C# now can differentiate between name and Name
        }

        public void AddGrade(char letter)
        { /* It is possible to have methods with same name. This is called method overloading. As long as methods have different signatures.
        It will work. Signature ex:
        Addgrade(char ee)
        AddGrade(String ee) are two different signatures. Return type is not important. It does not effect the signature*/
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;//lets you break out of switch.

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }


        }
        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >=0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }


        // List<double> grades= new List<double>();  Another way is to write a constructor
        // var doesn't work for fields! you can use this for everywhere within Book now


        public  event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics(){ 

            var result= new Statistics();
            result.Average=0.0;
            result.High=double.MinValue;
            result.Low=double.MaxValue;

            
            for (var index = 0; index < grades.Count; index++)
            {
             
                result.High= Math.Max(grades[index], result.High);
                result.Low=Math.Min(grades[index], result.Low);  
                result.Average+=grades[index];
                

            }
            result.Average/=grades.Count;

            switch(result.Average)
            {
                case var d when d>= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d>= 80.0:
                    result.Letter = 'B';
                    break;
                
                case var d when d>= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d>= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'A';
                    break;
            }

            
            return result;
        }
        private List<double> grades;

        public string Name
        {
            get;
            set; // Once defined book named can not be changed. Becomes Read-Only.
        
        }
       // private string name;

        // if it's private it can only be used within the class that is defined
        public const string CATEGORY = "Science";
        /* when you change category from readonly to const. You can not change it anywhere. You would've change the category name 
        in the public book class if you had readonly. As a nice code Constant values are usually written in 
        Uppercase letters. If you want to reach this const everywhere in the code you can also make it public (public const ...)  */
    }
}