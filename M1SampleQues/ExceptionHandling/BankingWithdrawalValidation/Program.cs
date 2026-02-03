using System;

class BankAccount
{
    static void Main()
    {
        int balance = 10000;

        try
        {
            Console.WriteLine("Enter withdrawal amount:");
            int amount = int.Parse(Console.ReadLine());

            // 1. Throw exception if amount <= 0
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            // 2. Throw exception if amount > balance
            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient balance.");
            }

            // 3. Deduct amount if valid
            balance -= amount;
            Console.WriteLine("Withdrawal successful.");
            Console.WriteLine("Remaining balance: " + balance);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid number.");
        }
        finally
        {
            // 4. Log transaction
            Console.WriteLine("Transaction completed.");
        }
    }
}
