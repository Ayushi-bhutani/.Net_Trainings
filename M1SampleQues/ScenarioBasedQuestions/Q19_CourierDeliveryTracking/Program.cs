using System;

class Program
{
    static void Main()
    {
        var courier = new CourierManager();

        // 1. Add Packages
        courier.AddPackage("Alice", "Bob", "New York", 2.5, "Parcel", 500);
        courier.AddPackage("Charlie", "David", "Los Angeles", 1.2, "Document", 100);
        courier.AddPackage("Eve", "Frank", "New York", 3.0, "Fragile", 800);

        // 2. Update Status
        var packageToUpdate = courier.GroupPackagesByType()["Parcel"][0].TrackingNumber;
        courier.UpdateStatus(packageToUpdate, "InTransit", "Sorting Center NY");

        // 3. Group Packages by Type
        var grouped = courier.GroupPackagesByType();
        Console.WriteLine("Packages by Type:");
        foreach (var g in grouped)
        {
            Console.WriteLine($"{g.Key}: {string.Join(", ", g.Value.ConvertAll(p => p.ReceiverName))}");
        }

        // 4. Packages by Destination
        var nyPackages = courier.GetPackagesByDestination("New York");
        Console.WriteLine("\nPackages to New York:");
        foreach (var p in nyPackages)
        {
            Console.WriteLine($"{p.ReceiverName}, Type: {p.PackageType}");
        }

        // 5. Delayed Packages
        var delayed = courier.GetDelayedPackages();
        Console.WriteLine("\nDelayed Packages:");
        foreach (var p in delayed)
        {
            Console.WriteLine($"{p.ReceiverName}, Estimated Delivery: {p.ShippingCost}");
        }
    }
}
