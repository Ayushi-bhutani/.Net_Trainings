namespace student{
    public class Program {
        public Student EvaluateStudent(int id, string name, double marks){
            Student student = new Student();

            if(marks < 0 || marks > 100){
                throw new InvalidMarksException("Invalid marks");
            }
            student.Id = id;
            student.Name = name;
            student.Marks = marks;

            return student;

        }

        public static void Main(String[] args){
            Program p = new Program();
            Console.WriteLine("Enter id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter marks");
            double marks = double.Parse(Console.ReadLine());

            try{
                Student student = p.EvaluateStudent(id, name, marks);
                Console.WriteLine("Student evaluated successfully");

            }catch(InvalidMarksException ex){
                Console.WriteLine(ex.Message);
            }


        }
    }


}
