using ECommerceProductCatalog.Managers;
using System;

class Program
{
    static void Main()
    {
        var inventory = new InventoryManager();

        // 1️⃣ Add Products
        inventory.AddProduct("Laptop", "Electronics", 75000, 10);
        inventory.AddProduct("T-Shirt", "Clothing", 999, 50);
        inventory.AddProduct("Headphones", "Electronics", 2999, 20);
        inventory.AddProduct("C# Book", "Books", 499, 30);

        // 2️⃣ Group By Category
        Console.WriteLine("🛒 Products Grouped By Category:\n");

        var grouped = inventory.GroupProductsByCategory();

        foreach (var category in grouped)
        {
            Console.WriteLine($"--- {category.Key} ---");
            category.Value.ForEach(p => Console.WriteLine(p));
            Console.WriteLine();
        }

        // 3️⃣ Update Stock
        Console.WriteLine("\n📦 Selling 2 units of P001...");
        inventory.UpdateStock("P001", 2);

        // 4️⃣ Products Under Budget
        Console.WriteLine("\n💸 Products Under ₹3000:\n");

        var cheapProducts = inventory.GetProductsBelowPrice(3000);
        cheapProducts.ForEach(p => Console.WriteLine(p));

        // 5️⃣ Stock Summary
        Console.WriteLine("\n📊 Stock Summary By Category:\n");

        var summary = inventory.GetCategoryStockSummary();
        foreach (var s in summary)
            Console.WriteLine($"{s.Key}: {s.Value} items");
    }
}
