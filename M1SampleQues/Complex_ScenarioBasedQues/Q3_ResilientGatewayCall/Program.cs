using System.Runtime;

namespace payment
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var service = new PaymentGatewayService();
            for(int i=1; i<=10; i++)
            {
                var request = new PaymentRequest
                {
                    PaymentId = $"PAY{i}",
                    AmbiguousImplementationException = 100
                };
                var result = await service.ProcessPaymentAsyn(request);
                Console.WriteLine($"{request.PaymentId} -> {result.Message}");
                await Task.Delay(2000);
            }
        }
    }
}