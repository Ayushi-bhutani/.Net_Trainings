namespace order
{
    public class OutOfStockException : Exception
    {
        public OutOfStockException(string message) : base(message) { }

    }
    public class PaymentFailedException : Exception
    {
        public PaymentFailedException (string message): base(message) {}
    }
}