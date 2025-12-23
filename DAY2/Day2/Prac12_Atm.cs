using System;

class ATMWithdrawal
{
    static void Main()
    {
        /*
         * Simulates ATM process using nested if
         */

        bool cardInserted = true;
        int correctPin = 1234;
        int balance = 5000;

        if (cardInserted)
        {
            Console.Write("Enter PIN: ");
            int pin = int.Parse(Console.ReadLine());

            if (pin == correctPin)
            {
                Console.Write("Enter withdrawal amount: ");
                int amount = int.Parse(Console.ReadLine());

                if (amount <= balance)
                    Console.WriteLine("Transaction Successful");
                else
                    Console.WriteLine("Insufficient Balance");
            }
            else
            {
                Console.WriteLine("Invalid PIN");
            }
        }
        else
        {
            Console.WriteLine("Insert Card First");
        }
    }
}
