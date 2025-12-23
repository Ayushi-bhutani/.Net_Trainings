namespace upipayment{

    public abstract class Payment{

        public decimal Amount { get; }
        protected Payment(decimal amount) => Amount = amount;

        public void PrintReciept(){
            Console.WriteLine($"Receipt: Amount={Amount}");
        }
        public abstract void Pay();
    }
    public class Upipayment : Payment{

        public string UpiId { get; }
        public Upipayment(decimal amount, string upiId) : base(amount) => UpiId = upiId;
        public override void Pay()
        {
            Console.WriteLine($"Paid {Amount} via UPI ({UpiId}).");
        }


    }
}