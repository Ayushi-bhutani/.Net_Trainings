namespace order
{
    public class Customer
    {
        public string CustomerName {get; set;}
        public int CustomerId{get; set;}
        public string CustomerMail {get; set;}
        public List<OrderItem> Cart = new();

       
    }
}