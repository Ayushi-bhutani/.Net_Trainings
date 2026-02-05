class Program
{
    static void Main()
    {
        RentalManager manager = new RentalManager();

        // Add Cars
        manager.AddCar("RJ14AB1234", "Toyota", "Camry", "Sedan", 2500);
        manager.AddCar("RJ14CD5678", "Hyundai", "Creta", "SUV", 3000);
        manager.AddCar("RJ14EF9012", "Maruti", "Ertiga", "Van", 2200);

        // Display Cars
        Console.WriteLine("Cars:");
        manager.DisplayCars();

        // Rent Car
        manager.RentCar(
            "RJ14AB1234",
            "Ayushi",
            DateTime.Now,
            3);

        // Active Rentals
        Console.WriteLine("\nActive Rentals:");
        manager.DisplayRentals();

        // Group by Type
        Console.WriteLine("\nAvailable Cars by Type:");
        var grouped = manager.GroupCarsByType();

        foreach (var g in grouped)
        {
            Console.WriteLine(g.Key);
            foreach (var c in g.Value)
                Console.WriteLine($"  {c.LicensePlate}");
        }

        // Revenue
        Console.WriteLine("\nTotal Revenue: ₹" +
            manager.CalculateTotalRentalRevenue());
    }
}
