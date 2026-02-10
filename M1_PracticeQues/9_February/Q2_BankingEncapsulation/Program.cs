namespace banking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BankAccount account = new BankAccount(600);
            account.Deposit(10);  
            Console.WriteLine($"balance : {account.balance}");
            account.Withdraw(100);
            Console.WriteLine($"balance : {account.balance}");
            account.Deposit(10);
            Console.WriteLine($"balance : {account.balance}");
            account.Withdraw(1000);
            Console.WriteLine($"balance : {account.balance}");
            account.Deposit(10);

            Console.WriteLine(account.balance);



        }
    }
}