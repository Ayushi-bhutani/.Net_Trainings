using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var inventory = new InventoryManager();

        // 1. Add Products
        inventory.AddProduct("P001", "Laptop", "Electronics", "Dell", 50000, 10, 5);
        inventory.AddProduct("P002", "Mouse", "Electronics", "Logitech", 1500, 50, 20);
        inventory.AddProduct("P003", "Notebook", "Stationery", "Classmate", 50, 100, 30);

        // 2. Update Stock
        inventory.UpdateStock("P001", "Out", 2, "Sale");
        inventory.UpdateStock("P003", "In", 50, "Purchase");

        // 3. Group Products by Category
        var grouped = inventory.GroupProductsByCategory();
        Console.WriteLine("Products by Category:");
        foreach (var g in grouped)
        {
            Console.WriteLine($"{g.Key}: {string.Join(", ", g.Value.ConvertAll(p => p.ProductName))}");
        }

        // 4. Get Low Stock Products
        var lowStock = inventory.GetLowStockProducts();
        Console.WriteLine("\nLow Stock Products:");
        foreach (var p in lowStock)
        {
            Console.WriteLine($"{p.ProductName} (Stock: {p.CurrentStock}, Min: {p.MinimumStockLevel})");
        }

        // 5. Stock Value by Category
        var stockValue = inventory.GetStockValueByCategory();
        Console.WriteLine("\nStock Value by Category:");
        foreach (var kvp in stockValue)
        {
            Console.WriteLine($"{kvp.Key}: ₹{kvp.Value}");
        }
    }
}
