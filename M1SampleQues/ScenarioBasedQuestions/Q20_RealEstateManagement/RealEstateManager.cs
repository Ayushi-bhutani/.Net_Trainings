using System;
using System.Collections.Generic;
using System.Linq;

public class RealEstateManager
{
    private List<Property> properties = new();
    private List<Client> clients = new();
    private List<Viewing> viewings = new();
    private int propertyCounter = 1;
    private int clientCounter = 1;
    private int viewingCounter = 1;

    public void AddProperty(string address, string type, int bedrooms,
                            double area, double price, string owner)
    {
        properties.Add(new Property
        {
            PropertyId = $"P{propertyCounter++:D3}",
            Address = address,
            PropertyType = type,
            Bedrooms = bedrooms,
            AreaSqFt = area,
            Price = price,
            Status = "Available",
            Owner = owner
        });
    }

    public void AddClient(string name, string contact, string type, double budget, List<string> requirements)
    {
        clients.Add(new Client
        {
            ClientId = clientCounter++,
            Name = name,
            Contact = contact,
            ClientType = type,
            Budget = budget,
            Requirements = requirements
        });
    }

    public bool ScheduleViewing(string propertyId, int clientId, DateTime date)
    {
        if (!properties.Any(p => p.PropertyId == propertyId) || !clients.Any(c => c.ClientId == clientId))
            return false;

        viewings.Add(new Viewing
        {
            ViewingId = viewingCounter++,
            PropertyId = propertyId,
            ClientId = clientId,
            ViewingDate = date
        });
        return true;
    }

    public Dictionary<string, List<Property>> GroupPropertiesByType()
    {
        return properties.GroupBy(p => p.PropertyType)
                         .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Property> GetPropertiesInBudget(double minPrice, double maxPrice)
    {
        return properties.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
    }
}
