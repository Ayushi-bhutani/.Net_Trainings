namespace order
{
    public class Order
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public int CustomerId{get; set;}
        public List<OrderItem> Items {get; set;}
        public decimal TotalAmount{get; set;}
        public string InvoiceNumber{get; set;}

        
    }
}