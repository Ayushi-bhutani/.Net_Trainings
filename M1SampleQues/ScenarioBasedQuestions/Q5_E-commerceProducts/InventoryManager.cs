using ECommerceProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceProductCatalog.Managers
{
    public class InventoryManager
    {
        private readonly List<Product> _products = new();
        private int _codeCounter = 0;

        // Add Product
        public void AddProduct(string name, string category,
                               double price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Invalid product details.");

            if (price <= 0 || stock < 0)
                throw new ArgumentException("Invalid price or stock.");

            _products.Add(new Product
            {
                ProductCode = $"P{(++_codeCounter).ToString("D3")}",
                ProductName = name,
                Category = category,
                Price = price,
                StockQuantity = stock
            });
        }

        // Group By Category
        public SortedDictionary<string, List<Product>> GroupProductsByCategory()
        {
            return new SortedDictionary<string, List<Product>>(
                _products
                .GroupBy(p => p.Category)
                .ToDictionary(g => g.Key, g => g.ToList())
            );
        }

        // Update Stock After Sale
        public bool UpdateStock(string productCode, int quantity)
        {
            var product = _products.FirstOrDefault(p => p.ProductCode == productCode);

            if (product == null || product.StockQuantity < quantity)
                return false;

            product.StockQuantity -= quantity;
            return true;
        }

        // Products Below Price
        public List<Product> GetProductsBelowPrice(double maxPrice)
        {
            return _products
                .Where(p => p.Price <= maxPrice)
                .OrderBy(p => p.Price)
                .ToList();
        }

        // Category Stock Summary
        public Dictionary<string, int> GetCategoryStockSummary()
        {
            return _products
                .GroupBy(p => p.Category)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(p => p.StockQuantity)
                );
        }

        // Helper
        public List<Product> GetAllProducts() => _products;
    }
}
