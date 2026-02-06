using System;

class Program
{
    static void Main()
    {
        var realEstate = new RealEstateManager();

        // 1. Add Properties
        realEstate.AddProperty("123 Main St", "Apartment", 2, 900, 50000, "Alice");
        realEstate.AddProperty("456 Elm St", "House", 3, 1500, 120000, "Bob");
        realEstate.AddProperty("789 Oak St", "Villa", 5, 3000, 350000, "Charlie");

        // 2. Add Clients
        realEstate.AddClient("David", "1234567890", "Buyer", 150000, new List<string> { "House", "3 Bedrooms" });
        realEstate.AddClient("Eva", "9876543210", "Renter", 50000, new List<string> { "Apartment" });

        // 3. Schedule Viewing
        realEstate.ScheduleViewing("P002", 1, DateTime.Now.AddDays(2));

        // 4. Group Properties by Type
        var grouped = realEstate.GroupPropertiesByType();
        Console.WriteLine("Properties by Type:");
        foreach (var g in grouped)
            Console.WriteLine($"{g.Key}: {string.Join(", ", g.Value.ConvertAll(p => p.Address))}");

        // 5. Properties in Budget
        var inBudget = realEstate.GetPropertiesInBudget(40000, 150000);
        Console.WriteLine("\nProperties in Budget:");
        foreach (var p in inBudget)
            Console.WriteLine($"{p.Address}, Price: {p.Price}");
    }
}
