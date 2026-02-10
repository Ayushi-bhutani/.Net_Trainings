using System.Text;

namespace invoice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int itemCount = 5;
            string[] itemNames = new string[itemCount];
            int[] qtys = new int[itemCount];
            double[] prices = new double[itemCount];

            for(int i=0 ; i<itemCount; i++)
            {
                Console.WriteLine("Item name: ");
                itemNames[i] = Console.ReadLine();

                Console.WriteLine("Quantity: ");
                qtys[i] = int.Parse(Console.ReadLine());

                Console.WriteLine("Price: ");
                prices[i] = double.Parse(Console.ReadLine());

            }

            StringBuilder invoice = new StringBuilder();
            double grandTotal =0;
            for(int i=0; i<itemCount; i++)
            {
                double lineTotal = qtys[i]*prices[i];
                grandTotal+= lineTotal;

                invoice.AppendLine($"{itemNames[i]} {qtys[i]} {prices[i]} {lineTotal}");
            }

            Console.WriteLine(grandTotal);
        }
    }
}