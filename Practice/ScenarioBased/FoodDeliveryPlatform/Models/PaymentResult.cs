namespace delivery
{
    public class PaymentResult
    {
        public bool IsSuccess { get; set; }
        public string TransactionId { get; set; }
        public string FailureReason { get; set; }
    }

    public class RefundResult
    {
        public bool IsSuccess { get; set; }
        public string RefundId { get; set; }
        public string FailureReason { get; set; }
    }

    public class PaymentNotification
    {
        public string TransactionId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
