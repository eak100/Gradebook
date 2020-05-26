using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args); //It is legal to define an empty delegate

    public class NamedObject
    { /* It is recommended to put each class in different files. However, for simplicity we skipped that.

    */
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();

    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {


            if (grade <= 100 && grade >= 0)
            {
                using (var writer = File.AppendText($"{Name}.txt"))
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }




            /*
            writer.WriteLine(grade);

            writer.Dispose(); // Clean up */
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }


    public class InMemoryBook : Book //Instead of defining getters and setters within the class we can also inherit this object from outside like this.
    {      // Book has a name and it is a NamedObject  
        public InMemoryBook(string name) : base(name)
        //Constructor has to have a same name with class
        {
            grades = new List<double>();
            Name = name; // C# now can differentiate between name and Name
        }

        public void AddGrade(char letter)
        { /* It is possible to have methods with same name. This is called method overloading. As long as methods have different signatures.
        It will work. Signature ex:
        Addgrade(char ee)
        AddGrade(String ee) are two different signatures. Return type is not important. It does not effect the signature*/
            switch (letter)
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
        public override void AddGrade(double grade) // to add polymorphism override term is added
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
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


        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);
            }

            return result;
        }
        private List<double> grades;
        public const string CATEGORY = "Science";
    }
}