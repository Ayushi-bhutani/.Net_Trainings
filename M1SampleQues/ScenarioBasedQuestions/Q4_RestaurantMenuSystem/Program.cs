using RestaurantMenuManagement.Managers;
using System;

class Program
{
    static void Main()
    {
        var menu = new MenuManager();

        // 1️⃣ Add Items
        menu.AddMenuItem("Paneer Tikka", "Appetizer", 250, true);
        menu.AddMenuItem("Chicken Wings", "Appetizer", 300, false);
        menu.AddMenuItem("Veg Biryani", "Main Course", 220, true);
        menu.AddMenuItem("Butter Chicken", "Main Course", 350, false);
        menu.AddMenuItem("Gulab Jamun", "Dessert", 120, true);

        // 2️⃣ Group By Category
        Console.WriteLine("🍽️ Menu Grouped By Category:\n");

        var grouped = menu.GroupItemsByCategory();

        foreach (var category in grouped)
        {
            Console.WriteLine($"--- {category.Key} ---");
            category.Value.ForEach(i => Console.WriteLine(i));
            Console.WriteLine();
        }

        // 3️⃣ Vegetarian Menu
        Console.WriteLine("\n🥗 Vegetarian Items:\n");

        var vegItems = menu.GetVegetarianItems();
        vegItems.ForEach(i => Console.WriteLine(i));

        // 4️⃣ Average Price
        Console.WriteLine(
            $"\n💰 Avg Main Course Price: ₹{menu.CalculateAveragePriceByCategory("Main Course")}"
        );
    }
}
