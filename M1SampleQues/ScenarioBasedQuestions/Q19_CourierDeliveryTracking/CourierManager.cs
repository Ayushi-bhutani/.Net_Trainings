using System;
using System.Collections.Generic;
using System.Linq;

public class CourierManager
{
    private List<Package> packages = new();
    private List<DeliveryStatus> statuses = new();

    public void AddPackage(string sender, string receiver, string address,
                           double weight, string type, double cost)
    {
        var trackingNumber = Guid.NewGuid().ToString();
        packages.Add(new Package
        {
            TrackingNumber = trackingNumber,
            SenderName = sender,
            ReceiverName = receiver,
            DestinationAddress = address,
            Weight = weight,
            PackageType = type,
            ShippingCost = cost
        });

        statuses.Add(new DeliveryStatus
        {
            TrackingNumber = trackingNumber,
            CurrentStatus = "Dispatched",
            EstimatedDelivery = DateTime.Now.AddDays(5)
        });
    }

    public bool UpdateStatus(string trackingNumber, string status, string checkpoint)
    {
        var ds = statuses.FirstOrDefault(s => s.TrackingNumber == trackingNumber);
        if (ds == null) return false;

        ds.CurrentStatus = status;
        ds.Checkpoints.Add(checkpoint);

        if (status == "Delivered")
            ds.ActualDelivery = DateTime.Now;

        return true;
    }

    public Dictionary<string, List<Package>> GroupPackagesByType()
    {
        return packages.GroupBy(p => p.PackageType)
                       .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Package> GetPackagesByDestination(string city)
    {
        return packages.Where(p => p.DestinationAddress.Contains(city, StringComparison.OrdinalIgnoreCase))
                       .ToList();
    }

    public List<Package> GetDelayedPackages()
    {
        return statuses.Where(s => s.CurrentStatus != "Delivered" && s.EstimatedDelivery < DateTime.Now)
                       .Join(packages, s => s.TrackingNumber, p => p.TrackingNumber, (s, p) => p)
                       .ToList();
    }
}
