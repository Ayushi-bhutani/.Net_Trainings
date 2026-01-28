namespace xam {
    public class UserInterface{

        public static void Main (String[] args){

            Console.WriteLine("Enter Exam Details:");
            Console.WriteLine("Student Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Question Type (MCQ/Coding):");
            string type = Console.ReadLine();

            Console.WriteLine("Total Questions:");
            int total = int.Parse(Console.ReadLine());

            Console.WriteLine("Correct Answers:");
            int correct = int.Parse(Console.ReadLine());

            Console.WriteLine("Wrong Answers:");
            int wrong = int.Parse(Console.ReadLine());

            
            OnlineTest test = new OnlineTest(name, total, correct, wrong, type);
            
            double percentage = test.calculateScore();

            string result = Exam.evaluateResult(percentage);


            Console.WriteLine("Exam Summary:");
            Console.WriteLine($"{type} Test: {name},  Total score: {percentage:F2}, Result: {result}");

        }
    }
}