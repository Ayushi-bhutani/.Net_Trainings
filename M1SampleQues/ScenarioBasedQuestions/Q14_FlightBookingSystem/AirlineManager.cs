using System;
using System.Collections.Generic;
using System.Linq;

public class AirlineManager
{
    private List<Flight> flights = new List<Flight>();
    private List<Booking> bookings = new List<Booking>();

    // Add a new flight
    public void AddFlight(string number, string origin, string destination, DateTime depart, DateTime arrive, int seats, double price)
    {
        flights.Add(new Flight(number, origin, destination, depart, arrive, seats, price));
        Console.WriteLine($"Flight {number} added successfully!");
    }

    // Book seats on a flight
    public bool BookFlight(string flightNumber, string passenger, int seats, string seatClass)
    {
        var flight = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
        if (flight == null)
        {
            Console.WriteLine("Flight not found.");
            return false;
        }
        if (seats <= 0 || seats > flight.AvailableSeats)
        {
            Console.WriteLine("Invalid number of seats requested.");
            return false;
        }

        double fare = seats * flight.TicketPrice;
        flight.AvailableSeats -= seats;

        bookings.Add(new Booking(flightNumber, passenger, seats, seatClass, fare));
        Console.WriteLine($"Booking successful for {passenger}. Total Fare: {fare:C}");
        return true;
    }

    // Group flights by destination
    public Dictionary<string, List<Flight>> GroupFlightsByDestination()
    {
        return flights.GroupBy(f => f.Destination)
                      .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Search flights by origin, destination, and date
    public List<Flight> SearchFlights(string origin, string destination, DateTime date)
    {
        return flights.Where(f => f.Origin == origin &&
                                  f.Destination == destination &&
                                  f.DepartureTime.Date == date.Date)
                      .ToList();
    }

    // Calculate total revenue for a flight
    public double CalculateTotalRevenue(string flightNumber)
    {
        return bookings.Where(b => b.FlightNumber == flightNumber)
                       .Sum(b => b.TotalFare);
    }
}
