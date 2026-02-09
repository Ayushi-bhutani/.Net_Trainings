using System.Net;
using System.Runtime;

namespace order
{
    public class PaymentService
    {
        public Payment ProcessPayment ( Order order)
        {
            if(new Random().Next(1,5) == 1)
            {
                throw new PaymentFailedException("Payment declined");

            }

            return new Payment
            {
                OrderId = order.OrderId,
                Amount = order.TotalAmount,
                Status = "Success"
            };
        }
    }
}