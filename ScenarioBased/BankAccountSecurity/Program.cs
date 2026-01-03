namespace std{
public class Program 
{
    public static void Main(String[] args){
        BankAccount p = new BankAccount();
       
        Console.WriteLine("Enter balance");
        int balance = int.Parse(Console.ReadLine());


        Console.WriteLine("Enter amount to deposit");
        int deposit = int.Parse(Console.ReadLine());

        p.Deposit(balance, deposit);


        Console.WriteLine("Enter amount to withdraw");
        int withdraw = int.Parse(Console.ReadLine());
        p.Withdraw(balance,withdraw);

    }
}}