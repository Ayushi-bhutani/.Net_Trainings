using System.Reflection.Metadata.Ecma335;

namespace order
{
    public class Program {
    public static void Main(String[] args)
    {
        var products = new List<Products>
        {
            new Product { ProductId = 1, Name = "Laptop", Price = 50000, Stock = 5},
            new Product { ProductId = 2, Name = "Mouse", Predicate = 500, Stock = 10}

        };

        var customer = new Customer
        {
            CustomerId = 101,
            Name = "Ayushi",
            Email = "ayu@test.com"
        };

        var orderService = new OrderService(products);
        try
        {
            orderService.AddToCart(customer, 1, 1);
            orderService.AddToCart(customer, 2, 2);
            var order = orderService.PlaceOrder(customer, "DISC10");

            Console.WriteLine($"Payment: {payment.Status}");

        }catch(Exception ex)
        {
            Console.WriteLine($"Order Failed: {ex.Message}");
        }

    }}
}