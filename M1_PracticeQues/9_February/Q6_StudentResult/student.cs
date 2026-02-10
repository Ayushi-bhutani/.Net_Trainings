using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace student {
    public class Person
    {
        public string Name{get; set;}
        public int Age{get; set;}

        public Person (string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
    }

    public class Student : Person
    {
        public int RollNo {get; set;}
        public int Marks{get; set;}
        public Student(string Name, int Age, int RollNo, int Marks) : base(Name, Age)
        {
            this.RollNo = RollNo;
            this.Marks = Marks;
        }
    }
}