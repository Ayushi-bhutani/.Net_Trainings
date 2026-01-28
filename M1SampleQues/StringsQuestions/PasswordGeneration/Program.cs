namespace password 
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the username");
            string user = Console.ReadLine();

            if(!Generate.IsValidUsername(user))
            {
                Console.WriteLine($"{user} is an invalid username");
                return;
            }
            
            string password = Generate.GetPassword(user);
            Console.WriteLine($"Password: {password}");
        }
    }
}