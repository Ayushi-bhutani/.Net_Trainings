namespace yoga
{
    public class Program
    {
        public static void Main(String[] args)
        {
            MeditationCenter mc = new MeditationCenter();
            Console.WriteLine("Add yoga members:");
            Console.WriteLine("Enter MemberId");
            int memberId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Age");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Weight");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Height");
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Goal");
            string goal = Console.ReadLine();

            

            
            mc.AddYogaMember(memberId, age,weight, height, goal);
            double bmi = mc.CalculateBMI(memberId);
            
            if(bmi==0){
                Console.WriteLine($"MemberId {memberId} is not present");
                return;
            }
            Console.WriteLine("BMI:"+bmi);

            int fee = mc.CalculateYogaFee(memberId);
            Console.WriteLine("Fee:"+fee);

                
            



            
        }
    }
}