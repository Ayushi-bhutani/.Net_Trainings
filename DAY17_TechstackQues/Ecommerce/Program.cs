namespace ecommerce{
    public class Program {
        
        public EcommerceShop MakePayment(string name, double balance, double amount){
            if(balance < amount){
                throw new InsufficientWalletBalanceException("Insufficient Balance in your digital wallet");
            }

            EcommerceShop e = new EcommerceShop();

            // Console.WriteLine("Enter user name");
            // string name = Console.ReadLine();
            e.UserName = name;

            // Console.WriteLine("Enter balance ");
            // double balance = double.Parse(Console.ReadLine());
            e.WalletBalance = balance;

            // Console.WriteLine("Enter amount ");
            // double amount = double.Parse(Console.ReadLine());
            e.TotalPurchaseAmount = amount;

            return e;
        }
        public static void Main(String[] args){
            Program p = new Program();

            Console.WriteLine("Enter user name");
            string name = Console.ReadLine();
            // e.UserName = name;

            Console.WriteLine("Enter balance ");
            double balance = double.Parse(Console.ReadLine());
            // e.WalletBalance = balance;

            Console.WriteLine("Enter amount ");
            double amount = double.Parse(Console.ReadLine());
            // e.TotalPurchaseAmount = amount;
            try{
                EcommerceShop result = p.MakePayment(name, balance, amount);
                Console.WriteLine("Payment successful");

            }catch(InsufficientWalletBalanceException ex){
                Console.WriteLine(ex.Message);
            }
            




        }
    }
}