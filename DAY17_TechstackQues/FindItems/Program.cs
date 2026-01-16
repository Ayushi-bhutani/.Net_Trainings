using System.Security.Cryptography.X509Certificates;

namespace items
{
    public class Program
    {
        public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>();

        
        public static void Main(String[] args)
        {

            Program p = new Program();
            Console.WriteLine("Enter total items:");
            int n = int.Parse(Console.ReadLine());
            for(int i=0; i<n; i++)
            {
                Console.WriteLine($"Enter name of {i} item: ");
                string name = Console.ReadLine();
                Console.WriteLine($"Enter count of {i} item: ");
                long count = long.Parse(Console.ReadLine());
                itemDetails.Add(name, count);
            }
            Console.WriteLine("Enter searchCount item: ");

            long searchCount = long.Parse(Console.ReadLine());

            var found = p.FindItemDetails(searchCount);
            if (found.Count == 0)
            {
                Console.WriteLine("Invalid Sold Count");
            }
            else
            {
                foreach(var x in found)
                {
                    Console.WriteLine(x.Key+ " "+x.Value);
                }
            }

            var minMax = p.FindMinandMaxSoldItems();
            if (minMax.Count == 2)
            {
                Console.WriteLine("Min: "+ minMax[0] );
                Console.WriteLine("Max: "+ minMax[1] );
            }
            var sorted = p.SortByCount();
            foreach(var x in sorted)
            {
                Console.WriteLine(x.Key+ " "+x.Value);
            }

        
        }
    }
}