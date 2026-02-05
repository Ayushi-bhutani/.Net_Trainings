using RestaurantMenuManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantMenuManagement.Managers
{
    public class MenuManager
    {
        private readonly List<MenuItem> _menu = new();

        // Add Menu Item
        public void AddMenuItem(string name, string category,
                                double price, bool isVeg)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Invalid menu details.");

            if (price <= 0)
                throw new ArgumentException("Price must be greater than 0.");

            _menu.Add(new MenuItem
            {
                ItemName = name,
                Category = category,
                Price = price,
                IsVegetarian = isVeg
            });
        }

        // Group By Category
        public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
        {
            return _menu
                .GroupBy(i => i.Category)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Vegetarian Items
        public List<MenuItem> GetVegetarianItems()
        {
            return _menu
                .Where(i => i.IsVegetarian)
                .OrderBy(i => i.Price)
                .ToList();
        }

        // Average Price By Category
        public double CalculateAveragePriceByCategory(string category)
        {
            var items = _menu
                .Where(i => i.Category.Equals(category,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!items.Any())
                return 0;

            return items.Average(i => i.Price);
        }

        // Helper
        public List<MenuItem> GetFullMenu() => _menu;
    }
}
