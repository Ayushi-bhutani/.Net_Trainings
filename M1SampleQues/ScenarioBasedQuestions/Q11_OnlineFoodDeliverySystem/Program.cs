class Program
{
    static void Main()
    {
        DeliveryManager dm = new DeliveryManager();

        // Add Restaurants
        dm.AddRestaurant("Spice Hub", "Indian", "Delhi", 40);
        dm.AddRestaurant("Pasta House", "Italian", "Noida", 50);

        // Add Food Items
        dm.AddFoodItem(1, "Butter Chicken", "Main Course", 250);
        dm.AddFoodItem(1, "Paneer Tikka", "Starter", 180);
        dm.AddFoodItem(2, "White Sauce Pasta", "Main Course", 220);

        Console.WriteLine("Restaurants:");
        dm.DisplayRestaurants();

        Console.WriteLine("\nMenu:");
        dm.DisplayMenu();

        // Place Order
        dm.PlaceOrder(101, new List<int> { 1, 2 });

        // Pending Orders
        Console.WriteLine("\nPending Orders:");
        var pending = dm.GetPendingOrders();

        foreach (var o in pending)
            Console.WriteLine($"Order {o.OrderId} | ₹{o.TotalAmount}");
        
        // Group Restaurants
        Console.WriteLine("\nRestaurants by Cuisine:");
        var grouped = dm.GroupRestaurantsByCuisine();

        foreach (var g in grouped)
        {
            Console.WriteLine(g.Key);
            foreach (var r in g.Value)
                Console.WriteLine($"  {r.Name}");
        }
    }
}
