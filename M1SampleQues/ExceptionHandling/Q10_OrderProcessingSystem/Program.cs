using System;

class OrderProcessor
{
    static void Main()
    {
        int[] orders = { 101, -1, 103 };

        // TODO:
        // 1. Process each order
        // 2. Throw exception for invalid order ID
        // 3. Ensure one failure does not stop processing
        foreach(var orderId in orders)
        {
            try
            {
                ProcessOrder(orderId);
                Console.WriteLine($"Order {orderId} processed successfully");
            }
            catch(InvalidOrderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
    public static void ProcessOrder(int orderId)
    {
        if(orderId <=0) 
            throw new InvalidOrderException("Order must be a positive number");
    }
    public class InvalidOrderException :Exception {
        public InvalidOrderException (string message) : base(message){ }
            
        
    }
    
}