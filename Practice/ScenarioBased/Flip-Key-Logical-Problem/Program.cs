using System;

namespace FlipFlop
{
    public class Program
    {
        //entry point
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the word");
            string input = Console.ReadLine();

            Flipflop obj = new Flipflop();
            string result = obj.CleanseAndInvert(input);

            if (string.IsNullOrEmpty(result))
                Console.WriteLine("Invalid Input");
            else
                Console.WriteLine($"The generated key is - {result}");
        }
    }
}
