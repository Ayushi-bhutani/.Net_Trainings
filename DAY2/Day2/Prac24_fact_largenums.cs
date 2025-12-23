using System;
using System.Numerics;

class LargeFactorial
{
    static void Main()
    {
        /*
         * Calculates factorial for large numbers
         */

        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        BigInteger fact = 1;
        for (int i = 1; i <= n; i++)
            fact *= i;

        Console.WriteLine("Factorial = " + fact);
    }
}
