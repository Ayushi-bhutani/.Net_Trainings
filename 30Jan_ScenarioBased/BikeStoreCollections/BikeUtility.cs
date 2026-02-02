using System.Collections.Generic;

public class BikeUtility
{
    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        Bike bike = new Bike
        {
            Model = model,
            Brand = brand,
            PricePerDay = pricePerDay
        };

        int key = Program.bikeDetails.Count + 1;
        Program.bikeDetails.Add(key, bike);
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> result = new SortedDictionary<string, List<Bike>>();

        foreach (var item in Program.bikeDetails)
        {
            Bike bike = item.Value;

            if (!result.ContainsKey(bike.Brand))
            {
                result[bike.Brand] = new List<Bike>();
            }

            result[bike.Brand].Add(bike);
        }

        return result;
    }
}
