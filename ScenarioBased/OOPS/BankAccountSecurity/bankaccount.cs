namespace std{
public class BankAccount
{
    protected int? balance{get; set;}
    public int? amount{get; set;}
    public void Deposit(int balance, int amount)
    {
        balance += amount;
        Console.WriteLine($"Updated balance is {balance}");
    }

    public void Withdraw(int balance, int amount)
    {
        if(amount < balance)
        {
            balance -= amount;
            Console.WriteLine($"Updated balance is {balance}");
        }
        else
        {
            Console.WriteLine("Enter valid amount to withdraw  ");
        }
    }
    


}}