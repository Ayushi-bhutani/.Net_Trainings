using System.Security.Cryptography.X509Certificates;

namespace cab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter cab type");
            string type = Console.ReadLine();
            int km = 10;
            if(type == "Mini")
            {
                Cab cab1 = new Mini();
                double fare1 = cab1.CalculateFare(km);
                Console.WriteLine(fare1);
            }
            else if ( type == "Sedan")
            {
                Cab cab2 = new Sedan();
                double fare2 = cab2.CalculateFare(km);
                Console.WriteLine(fare2);
            }
            else if(type == "SUV")
            {
                Cab cab3  = new SUV();
                double fare3 = cab3.CalculateFare(km);
                Console.WriteLine(fare3);
            }

        }
    }
}