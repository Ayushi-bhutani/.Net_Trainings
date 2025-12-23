using System;

class PascalTriangle
{
    static void Main()
    {
        /*
         * Prints Pascal's Triangle
         */

        Console.Write("Enter Rows: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int val = 1;
            for (int j = 0; j <= i; j++)
            {
                Console.Write(val + " ");
                val = val * (i - j) / (j + 1);
            }
            Console.WriteLine();
        }
    }
}
