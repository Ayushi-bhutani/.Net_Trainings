namespace order
{
    public class Payment
    {
        public Guid PaymentId{get; set;} = Guid.NewGuid();
        public Guid OrderId { get; set; } 
        public string status{get; set;}
        public decimal Amount {get; set;}
    }
}