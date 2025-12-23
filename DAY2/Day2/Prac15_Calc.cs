using System;

class Calculator
{
    static void Main()
    {
        /*
         * Performs basic arithmetic using switch
         */

        Console.Write("Enter First Number: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter Second Number: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Enter Operator (+ - * /): ");
        char op = Console.ReadLine()[0];

        switch (op)
        {
            case '+': Console.WriteLine(a + b); break;
            case '-': Console.WriteLine(a - b); break;
            case '*': Console.WriteLine(a * b); break;
            case '/':
                Console.WriteLine(b != 0 ? a / b : "Division by zero");
                break;
            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
}
