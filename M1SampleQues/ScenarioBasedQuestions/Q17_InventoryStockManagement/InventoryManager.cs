using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryManager
{
    private List<Product> products = new();
    private List<StockMovement> movements = new();
    private int movementCounter = 1;

    public void AddProduct(string code, string name, string category,
                           string supplier, double price, int stock, int minLevel)
    {
        if (!products.Any(p => p.ProductCode == code))
        {
            products.Add(new Product
            {
                ProductCode = code,
                ProductName = name,
                Category = category,
                Supplier = supplier,
                UnitPrice = price,
                CurrentStock = stock,
                MinimumStockLevel = minLevel
            });
        }
    }

    public bool UpdateStock(string productCode, string movementType, int quantity, string reason)
    {
        var product = products.FirstOrDefault(p => p.ProductCode == productCode);
        if (product == null) return false;

        if (movementType == "Out" && product.CurrentStock < quantity) return false;

        if (movementType == "In") product.CurrentStock += quantity;
        else product.CurrentStock -= quantity;

        movements.Add(new StockMovement
        {
            MovementId = movementCounter++,
            ProductCode = productCode,
            MovementDate = DateTime.Now,
            MovementType = movementType,
            Quantity = quantity,
            Reason = reason
        });

        return true;
    }

    public Dictionary<string, List<Product>> GroupProductsByCategory()
    {
        return products.GroupBy(p => p.Category)
                       .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Product> GetLowStockProducts()
    {
        return products.Where(p => p.CurrentStock < p.MinimumStockLevel).ToList();
    }

    public Dictionary<string, int> GetStockValueByCategory()
    {
        return products.GroupBy(p => p.Category)
                       .ToDictionary(g => g.Key, g => (int)g.Sum(p => p.CurrentStock * p.UnitPrice));
    }
}
