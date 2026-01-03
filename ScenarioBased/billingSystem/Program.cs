namespace billing{
    public class Program {
        public static void Main(String[] args){
            Billing bill = new Billing();
            Console.WriteLine("Price only: "+ bill.CalculateTotal(1000));
            Console.WriteLine("Price + tax : "+ bill.CalculateTotal(1000,10));
            Console.WriteLine("Price + tax + discount: "+ bill.CalculateTotal(1000, 10, 5));

        }
    }
}