namespace delivery
{
    public class OrderProcessingEngine
    {
        /// <summary>
        /// private field of IPaymentService interface 
        /// </summary>
        private readonly IPaymentService _paymentService;
        /// <summary>
        ///  private field of IRestaurantService interface 
        /// </summary>
        private readonly IRestaurantService _restaurantService;
        
        /// <summary>
        ///  private field of IDriverService interface 
        /// </summary>
        private readonly IDriverService _driverService;
        /// <summary>
        ///  private field of OrderProcessingEngine class 
        /// </summary>
        private readonly ILogger<OrderProcessingEngine> _logger;

        /// <summary>
        /// parameterised constructor of OrderProcessingEngine class 
        /// </summary>
        /// <param name="paymentService"></param>
        /// <param name="restaurantService"></param>
        /// <param name="driverService"></param>
        /// <param name="logger"></param>
        public OrderProcessingEngine(
            IPaymentService paymentService,
            IRestaurantService restaurantService,
            IDriverService driverService,
            ILogger<OrderProcessingEngine> logger)
        {
            _paymentService = paymentService;
            _restaurantService = restaurantService;
            _driverService = driverService;
            _logger = logger;
        }


        public async Task<OrderProcessingResult> ProcessOrderAsync(CustomerOrder order, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Processing order {order.OrderId}");

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            cts.CancelAfter(TimeSpan.FromMinutes(2));

            try
            {
                ValidateOrder(order);
                order.Status = OrderStatus.PaymentPending;
                PaymentResult paymentResult = await ProcessPaymentWithRetryAsync(order, 3, cts.Token);
                if(!paymentResult.IsSuccess)
                    throw new PaymentFailedException(paymentResult.FailureReason);

                order.Status = OrderStatus.PaymentSuccessful;
                var acceptTask = _restaurantService.AcceptOrderAsync(order, cts.Token);
                if(await Task.WhenAny(acceptTask, Task.Delay(TimeSpan.FromSeconds(45), cts.Token)) != acceptTask)
                    throw new TimeoutException("Restaurant acceptance timed out");
                var acceptance = await acceptTask;
                if(!acceptance.IsAccepted)
                    throw new Exception($"Restaurant rejected order {acceptance.reason}");

                

                `

            }
            catch ()
            {
                
            }
        }

    

    }
}