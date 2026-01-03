namespace onlinegateway{

    public class Online
    {
        //virtual keyword is used to make method may or may not be override 
        public virtual void ProcessPayment(string paymentType)
        {
            Console.WriteLine("Processing payment");
        }

    }

    public class Gateway : Online
    {
        public override void ProcessPayment(string paymentType)
        {
            if(paymentType == "CreditCard")
            {
                Console.WriteLine("Processing card payment");
            }
            else if(paymentType == "UPI")
            {
                Console.WriteLine("Processing UPI payment");
            }
            else if(paymentType == "NetBanking")
            {
                Console.WriteLine("Processing NetBanking payment");
            }
            else 
            {
                Console.WriteLine("Invalid payment method");
            }

        }
    }
}