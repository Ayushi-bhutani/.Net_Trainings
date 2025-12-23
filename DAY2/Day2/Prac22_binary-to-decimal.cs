using System;

class BinaryToDecimal
{
    static void Main()
    {
        /*
         * Converts Binary to Decimal manually
         */

        Console.Write("Enter Binary: ");
        string binary = Console.ReadLine();

        int decimalValue = 0;

        foreach (char c in binary)
            decimalValue = decimalValue * 2 + (c - '0');

        Console.WriteLine("Decimal = " + decimalValue);
    }
}
