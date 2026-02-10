namespace student
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Student st1 = new Student("Ayushi", 22, 101, 78);

            if(st1.Marks < 35) Console.WriteLine("Fail");
            else {
                Console.WriteLine("Pass");
                Console.WriteLine(st1.Name);
                Console.WriteLine(st1.Age);
                Console.WriteLine(st1.RollNo);
                Console.WriteLine(st1.Marks);
            }
    }
}
}