using System;
using LogicalPrograms;
namespace LogicalPrograms
{
    class Program
{
   public  static void Main()
    {
        // Palindrome check
        Console.Write("Enter a word or sentence: ");
        string? input = Console.ReadLine();
        // Using the extension method from Palindrome class
        bool result = input.IsPalindrome();
        if (result)
            Console.WriteLine("It is a Palindrome.");
        else
            Console.WriteLine("It is NOT a Palindrome.");
    }
}
}