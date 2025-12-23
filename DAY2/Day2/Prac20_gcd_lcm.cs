using System;

class GcdLcm
{
    static void Main()
    {
        /*
         * Finds GCD and LCM
         */

        Console.Write("Enter two numbers: ");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        int x = a, y = b;

        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        Console.WriteLine("GCD = " + a);
        Console.WriteLine("LCM = " + (x * y) / a);
    }
}
