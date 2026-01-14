using System.Numerics;

public class Linq


{
    public class Marks
    {
        public int? marks1;
        public int? marks2;

    }
    public static void Main(String[] args)
    {
        MaxLINQ();
        Console.ReadLine();
    }

    private static void MaxLINQ(){
        Marks[] students =
        {
            new Marks { marks1 = 80, marks2= 90},
            new Marks { marks1 = 89, marks2= 99}

        };

        int? maxMarks1 = students.Max(s=>s.marks1);
        int? maxMarks2 = students.Max(s=>s.marks2);


        Console.WriteLine("max marks 1 "+maxMarks1);
        Console.WriteLine("max marks 2 "+maxMarks2);

        


    }
}