using System;

namespace FlipFlop
{
    public class Program
    {
        // Entry point
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

    public class Flipflop
    {
        public string CleanseAndInvert(string input)
        {
            // 1. Validate null or length < 6
            if (string.IsNullOrEmpty(input) || input.Length < 6)
                return string.Empty;

            // 2. Validate only alphabets
            foreach (char ch in input)
            {
                if (!char.IsLetter(ch))
                    return string.Empty;
            }

            // 3. Convert to lowercase
            string lower = input.ToLower();

            // 4. Remove characters whose ASCII value is EVEN
            string filtered = "";
            foreach (char ch in lower)
            {
                if (ch % 2 != 0)
                    filtered += ch;
            }

            // 5. Reverse the string
            char[] arr = filtered.ToCharArray();
            Array.Reverse(arr);
            string reversed = new string(arr);

            // 6. Uppercase characters at EVEN index
            char[] finalChars = reversed.ToCharArray();
            for (int i = 0; i < finalChars.Length; i++)
            {
                if (i % 2 == 0)
                    finalChars[i] = char.ToUpper(finalChars[i]);
            }

            return new string(finalChars);
        }
    }
}
