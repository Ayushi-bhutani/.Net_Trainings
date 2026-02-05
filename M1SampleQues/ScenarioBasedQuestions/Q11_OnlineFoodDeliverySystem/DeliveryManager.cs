using System;
using System.Collections.Generic;
using System.Linq;

public class DeliveryManager
{
    private List<Restaurant> restaurants = new();
    private List<FoodItem> foodItems = new();
    private List<Order> orders = new();

    private int restaurantCounter = 1;
    private int foodItemCounter = 1;
    private int orderCounter = 1;

    // Add Restaurant
    public void AddRestaurant(string name, string cuisine,
                              string location, double charge)
    {
        restaurants.Add(new Restaurant
        {
            RestaurantId = restaurantCounter++,
            Name = name,
            CuisineType = cuisine,
            Location = location,
            DeliveryCharge = charge
        });
    }

    // Add Food Item
    public void AddFoodItem(int restaurantId, string name,
                            string category, double price)
    {
        if (!restaurants.Any(r => r.RestaurantId == restaurantId))
            throw new Exception("Restaurant not found");

        foodItems.Add(new FoodItem
        {
            ItemId = foodItemCounter++,
            Name = name,
            Category = category,
            Price = price,
            RestaurantId = restaurantId
        });
    }

    // Group Restaurants by Cuisine
    public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
    {
        return restaurants
            .GroupBy(r => r.CuisineType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Place Order
    public bool PlaceOrder(int customerId, List<int> itemIds)
    {
        var selectedItems = foodItems
            .Where(i => itemIds.Contains(i.ItemId))
            .ToList();

        if (!selectedItems.Any())
            return false;

        double foodTotal = selectedItems.Sum(i => i.Price);
        double delivery = restaurants
            .First(r => r.RestaurantId == selectedItems[0].RestaurantId)
            .DeliveryCharge;

        orders.Add(new Order
        {
            OrderId = orderCounter++,
            CustomerId = customerId,
            Items = selectedItems,
            OrderTime = DateTime.Now,
            Status = "Pending",
            TotalAmount = foodTotal + delivery
        });

        return true;
    }

    // Get Pending Orders
    public List<Order> GetPendingOrders()
    {
        return orders
            .Where(o => o.Status == "Pending")
            .ToList();
    }

    // Helper Displays
    public void DisplayRestaurants()
    {
        foreach (var r in restaurants)
            Console.WriteLine($"{r.RestaurantId} - {r.Name} ({r.CuisineType})");
    }

    public void DisplayMenu()
    {
        foreach (var f in foodItems)
            Console.WriteLine($"{f.ItemId} - {f.Name} ₹{f.Price}");
    }
}
