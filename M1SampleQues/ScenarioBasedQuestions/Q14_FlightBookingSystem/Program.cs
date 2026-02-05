using System;

class Program
{
    static void Main()
    {
        AirlineManager manager = new AirlineManager();

        // Add flights
        manager.AddFlight("AI101", "Delhi", "Mumbai", DateTime.Now.AddHours(5), DateTime.Now.AddHours(7), 150, 5000);
        manager.AddFlight("AI102", "Delhi", "Bangalore", DateTime.Now.AddHours(6), DateTime.Now.AddHours(9), 120, 6000);

        // Book flights
        manager.BookFlight("AI101", "Alice", 2, "Economy");
        manager.BookFlight("AI102", "Bob", 1, "Business");

        // Group flights by destination
        var grouped = manager.GroupFlightsByDestination();
        foreach (var group in grouped)
        {
            Console.WriteLine($"\nDestination: {group.Key}");
            foreach (var f in group.Value)
            {
                Console.WriteLine($"Flight: {f.FlightNumber}, Seats Available: {f.AvailableSeats}");
            }
        }

        // Search flights
        Console.WriteLine("\nSearch Flights from Delhi to Mumbai today:");
        var searchResults = manager.SearchFlights("Delhi", "Mumbai", DateTime.Now);
        foreach (var f in searchResults)
        {
            Console.WriteLine($"Flight: {f.FlightNumber}, Departure: {f.DepartureTime}, Price: {f.TicketPrice}");
        }

        // Calculate revenue
        Console.WriteLine($"\nTotal revenue for AI101: {manager.CalculateTotalRevenue("AI101"):C}");
    }
}
