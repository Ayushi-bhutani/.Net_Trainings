namespace payment
{
    public class PaymentRequest
    {
        public string PaymentId{get; set;}
        public double Amount {get; set;}

    }

    public class PaymentResult
    {
        public bool Success{get; set;}
        public string Message {get; set;}

    }

    public class PaymentGatewayService
    {
        private const int MAX_RETRIES = 3;
        private const int FAILURE_THRESHOLD = 5;
        private static readonly TimeSpan FAILURE_WINDOW = TimeSpan.FromMinutes(1);
        private static readonly TimeSpan CIRCUIT_OPEN_TIME = TimeSpan.FromSeconds(30);

        private readonly List<DateTime> failureTimeStamps = new List<DateTime>();
        private bool circuitOpen = false;
        private DateTime circuitOpenedAt;
        public async Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request)
        {
            if (IsCircuitOpen())
            {
                return new PaymentResult
                {
                    Success = false,
                    Message = "Circuit is OPEN. Try again later."
                };
            }

            int retryCount =0;
            while(retryCount < MAX_RETRIES)
            {
                try
                {
                    var result = await CallPaymentGateway(request);
                    if(result.Success)
                        return result;

                    RegisterFailure();
                    retryCount++;
                }
                catch (TimeoutException)
                {
                    RegisterFailure();
                    retryCount++;
                }
            }
            return new PaymentResult
            {
                Success = false,
                Message = "Payment failed after retries."
            };
        }
        private bool IsCircuitOpen()
        {
            if (!CircuitOpen)
            {
                return false;
            }
            if(DateTime.UtcNow - circuitOpenedAt > CIRCUIT_OPEN_TIME)
            {
                circuitOpen = false;
                failureTimeStamps.Clear();
                return false;
            }
            return true;
        }
        private void RegisterFailure()
        {
            var now = DateTime.UtcNow;
            failureTimeStamps.Add(now);
            failureTimeStamps.RemoveAll(t => now -t > FAILURE_WINDOW);

            if(failureTimeStamps.Count >= FAILURE_THRESHOLD)
            {
                circuitOpen = true;
                circuitOpenedAt = now;
            }
        }
        private async Task <PaymentResult> CallPaymentGateway(PaymentRequest request)
        {
            await Task.Delay(500);
            var random = new Random();
            int value = random.Next(1,4);
            if(value == 1)
                throw new TimeoutException();
            if(value == 2)
                return new PaymentResult {Success = false, Message = "Gateway error"};
            return new PaymentResult {Success = true, Message = "Payment successful"};

        }

    }


}