using System;

class StrongNumber
{
    static void Main()
    {
        /*
         * Checks Strong Number
         */

        Console.Write("Enter Number: ");
        int num = int.Parse(Console.ReadLine());
        int temp = num, sum = 0;

        while (temp > 0)
        {
            int d = temp % 10;
            int fact = 1;

            for (int i = 1; i <= d; i++)
                fact *= i;

            sum += fact;
            temp /= 10;
        }

        Console.WriteLine(sum == num ? "Strong Number" : "Not Strong");
    }
}
