using System;

class DigitalRoot
{
    static void Main()
    {
        /*
         * Sums digits until single digit remains
         */

        Console.Write("Enter Number: ");
        int n = int.Parse(Console.ReadLine());

        while (n >= 10)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            n = sum;
        }

        Console.WriteLine("Digital Root = " + n);
    }
}
