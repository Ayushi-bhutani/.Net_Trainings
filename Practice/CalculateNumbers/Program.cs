namespace nums{
    public class Program {


        public static void Main(String[] args){

            Numbers p = new Numbers();
            Console.WriteLine("Enter how many numbers to be added:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                p.AddNumbers(num);
            }

            double gpa = p.GetGPAScored();

            if (gpa == -1)
            {
                Console.WriteLine("No Numbers Available");
                return;
            }

            Console.WriteLine("GPA: " + gpa);

            char grade = p.GetGradeScored(gpa);

            if (grade == '\0')
            {
                Console.WriteLine("Invalid GPA");
            }
            else
            {
                Console.WriteLine("Grade: " + grade);
            }



        }
    }
}