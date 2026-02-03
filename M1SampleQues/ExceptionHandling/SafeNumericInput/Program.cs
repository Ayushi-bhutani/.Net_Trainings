using System;

class InputHandler
{
    static void Main()

    {
        int num;
        bool isValid = false;
        while (!isValid)
        {
            Console.WriteLine("Enter a number:");
            try
            {
                string input = Console.ReadLine();
                isValid = true;
                Console.WriteLine("Valid number entered: " + num);

            }

        catch(FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        catch(OverflowException)
        {
            Console.WriteLine("Number is too large or too small.");
        }
        // TODO:
        // 1. Read input from user
        // 2. Handle invalid numeric input
        // 3. Keep asking until valid number is entered
    }
}}