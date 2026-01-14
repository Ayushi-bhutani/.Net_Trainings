namespace genericsLinq
{
    class Program
{
    /// <summary>
    /// base class Student
    /// </summary>
    class Student
    {
        /// <summary>
        /// property ID defined 
        /// </summary>
        public int ID;
        /// <summary>
        /// property Name defined 
        /// </summary>
        public string? Name;
        /// <summary>
        /// property Marks defined 
        /// </summary>
        public int Marks;


    }
    /// <summary>
    /// entry point of program
    /// </summary>
    /// <param name="args"></param>
    public static void Main(String[] args)
    {

        //list that can only contain objects of student class <Student> -- datatype 
        List <Student> students = new List<Student> (){
            new Student { ID = 1, Name= "Ayushi",Marks= 90},
            new Student { ID = 2, Name= "Akram",Marks= 99},
            new Student { ID = 3, Name= "Arzoo",Marks= 60}

        };

        var passedStudents = 
                    from s in students
                    where s.Marks > 75
                    select s;
        Console.WriteLine("Passed students");

        foreach(var s in passedStudents)
        {
            Console.WriteLine(s.Name + " " + s.Marks);
        }

        var names = 
            from s in students
            select s.Name;
        Console.WriteLine("Student names");

        foreach(var s in names)
        {
            Console.WriteLine(s);
        }



        int maxMarks = 
            (from s in students
            select s.Marks).Max();

        Console.WriteLine("maxmarks "+ maxMarks);


        var topper = 
                (from s in students
                orderby s.Marks descending
                select s).First();

        Console.WriteLine("Topper: "+topper.Name);


//LINQ = language integrated query 


    }
}
}
