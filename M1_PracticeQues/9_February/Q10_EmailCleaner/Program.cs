using System.Security.AccessControl;

namespace email
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            email = email.Trim();
            email = email.ToLower();
            if (email.Contains("gmail.com"))
            {
                email = email.Replace("gmail.com","company.com");
            }

            Console.WriteLine( email);
        }
    }
}