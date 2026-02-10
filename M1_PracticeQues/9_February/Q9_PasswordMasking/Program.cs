using System.Security.Cryptography.X509Certificates;
namespace password
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter password");
            string input = Console.ReadLine();
            string masked = mask(input);
            Console.WriteLine(masked);
        }

        public static string mask(string input)
        {
            string ans = "";       
            if(input.Length > 3) return input;
            ans += input[0];
            for(int i=1; i<input.Length-1; i++)
            {
                ans += '*';
            }
            int n = input.Length;
            
            ans += input[n-1];
            return ans;

        }
    }
    
}