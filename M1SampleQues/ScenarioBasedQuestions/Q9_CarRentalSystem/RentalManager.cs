public class RentalManager
{
    private List<RentalCar> cars = new List<RentalCar>();
    private List<Rental> rentals = new List<Rental>();

    private int rentalCounter = 1;

    // Add Car
    public void AddCar(string license,
                       string make,
                       string model,
                       string type,
                       double rate)
    {
        cars.Add(new RentalCar
        {
            LicensePlate = license,
            Make = make,
            Model = model,
            CarType = type,
            DailyRate = rate,
            IsAvailable = true
        });
    }

    // Rent Car
    public bool RentCar(string license,
                        string customer,
                        DateTime start,
                        int days)
    {
        var car = cars.FirstOrDefault(c =>
            c.LicensePlate == license &&
            c.IsAvailable);

        if (car == null)
        {
            Console.WriteLine("Car not available.");
            return false;
        }

        var rental = new Rental
        {
            RentalId = rentalCounter++,
            LicensePlate = license,
            CustomerName = customer,
            StartDate = start,
            EndDate = start.AddDays(days),
            TotalCost = days * car.DailyRate
        };

        rentals.Add(rental);
        car.IsAvailable = false;

        return true;
    }

    // Group Cars by Type
    public Dictionary<string, List<RentalCar>>
        GroupCarsByType()
    {
        return cars
            .Where(c => c.IsAvailable)
            .GroupBy(c => c.CarType)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Active Rentals
    public List<Rental> GetActiveRentals()
    {
        DateTime today = DateTime.Now;

        return rentals
            .Where(r => r.EndDate >= today)
            .ToList();
    }

    // Total Revenue
    public double CalculateTotalRentalRevenue()
    {
        return rentals.Sum(r => r.TotalCost);
    }

    // Display Helpers
    public void DisplayCars()
    {
        foreach (var c in cars)
        {
            Console.WriteLine(
                $"{c.LicensePlate} | {c.Make} {c.Model} | {c.CarType} | " +
                $"Available: {c.IsAvailable}");
        }
    }

    public void DisplayRentals()
    {
        foreach (var r in rentals)
        {
            Console.WriteLine(
                $"ID:{r.RentalId} | {r.CustomerName} | {r.LicensePlate} | " +
                $"{r.StartDate:d} → {r.EndDate:d} | ₹{r.TotalCost}");
        }
    }
}
