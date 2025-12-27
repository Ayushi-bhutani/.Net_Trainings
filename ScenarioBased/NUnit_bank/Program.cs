using System;

namespace bank
{
    public class Program
    {
        public decimal Balance { get; private set; }
        //constructor for program class 
        public Program(decimal balance)
        {
            Balance = balance;
        }
        //method to deposit amount
        public void Deposit(decimal amount)
        {
            if (amount < 0)
                throw new Exception("Deposit amount cannot be negative");

            Balance += amount;
        }
        //method to withdraw ammount
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient funds.");

            Balance -= amount;
        }
    }
}
