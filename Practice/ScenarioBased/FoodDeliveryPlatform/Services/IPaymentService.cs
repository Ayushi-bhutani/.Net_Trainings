namespace delivery {
public interface IPaymentService
{
    /// <summary>
    /// Authorizes payment for a given amount and customer.
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="customerId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<PaymentResult> AuthorizePaymentAsync(
        decimal amount, 
        string customerId, 
        CancellationToken ct);

    /// <summary>
    /// Captures a previously authorized payment.
    /// </summary>
    /// <param name="transactionId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<PaymentResult> CapturePaymentAsync(
        string transactionId, 
        CancellationToken ct);
    
    /// <summary>
    /// Refunds a payment.
    /// </summary>
    /// <param name="transactionId"></param>
    /// <param name="amount"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<RefundResult> RefundPaymentAsync(
        string transactionId, 
        decimal amount, 
        CancellationToken ct);
    

    /// <summary>
    /// Webhook for async payment notifications
    /// </summary>
    
    event Func<PaymentNotification, Task> PaymentNotificationReceived;
}
}