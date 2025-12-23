using System;

class DiamondPattern
{
    static void Main()
    {
        /*
         * Prints diamond star pattern
         */

        Console.Write("Enter Rows: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
            Console.WriteLine(new string(' ', n - i) + new string('*', 2 * i - 1));

        for (int i = n - 1; i >= 1; i--)
            Console.WriteLine(new string(' ', n - i) + new string('*', 2 * i - 1));
    }
}
