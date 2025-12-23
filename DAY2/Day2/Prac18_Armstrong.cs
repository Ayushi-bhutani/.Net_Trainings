using System;

class ArmstrongNumber
{
    static void Main()
    {
        /*
         * Checks Armstrong number
         */

        Console.Write("Enter Number: ");
        int num = int.Parse(Console.ReadLine());
        int temp = num, sum = 0, digits = num.ToString().Length;

        while (temp > 0)
        {
            int d = temp % 10;
            sum += (int)Math.Pow(d, digits);
            temp /= 10;
        }

        Console.WriteLine(sum == num ? "Armstrong" : "Not Armstrong");
    }
}
