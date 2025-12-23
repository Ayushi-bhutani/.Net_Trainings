using System;

class ContinueExample
{
    static void Main()
    {
        /*
         * Prints numbers from 1 to 50
         * Skips multiples of 3
         */

        for (int i = 1; i <= 50; i++)
        {
            if (i % 3 == 0)
                continue;

            Console.Write(i + " ");
        }
    }
}
