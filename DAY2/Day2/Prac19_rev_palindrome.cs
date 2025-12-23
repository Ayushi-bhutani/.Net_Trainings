using System;

class PalindromeCheck
{
    static void Main()
    {
        /*
         * Reverses number and checks palindrome
         */

        Console.Write("Enter Number: ");
        int num = int.Parse(Console.ReadLine());
        int temp = num, rev = 0;

        while (temp > 0)
        {
            rev = rev * 10 + temp % 10;
            temp /= 10;
        }

        Console.WriteLine(rev == num ? "Palindrome" : "Not Palindrome");
    }
}
