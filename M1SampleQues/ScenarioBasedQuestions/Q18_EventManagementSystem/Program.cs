using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var eventManager = new EventManager();

        // 1. Create Events
        eventManager.CreateEvent("Rock Concert", "Concert", DateTime.Now.AddDays(10), "Stadium", 5000, 1500);
        eventManager.CreateEvent("Tech Conference", "Conference", DateTime.Now.AddDays(30), "Convention Center", 1000, 3000);
        eventManager.CreateEvent("Photography Workshop", "Workshop", DateTime.Now.AddDays(5), "Studio", 20, 500);

        // 2. Book Tickets
        eventManager.BookTicket(1, 101, "A1");
        eventManager.BookTicket(1, 102, "A2");
        eventManager.BookTicket(2, 103, "B1");

        // 3. Group Events by Type
        var groupedEvents = eventManager.GroupEventsByType();
        Console.WriteLine("Events by Type:");
        foreach (var g in groupedEvents)
        {
            Console.WriteLine($"{g.Key}: {string.Join(", ", g.Value.ConvertAll(e => e.EventName))}");
        }

        // 4. Get Upcoming Events in next 15 days
        var upcoming = eventManager.GetUpcomingEvents(15);
        Console.WriteLine("\nUpcoming Events in 15 days:");
        foreach (var e in upcoming)
        {
            Console.WriteLine($"{e.EventName} on {e.EventDate.ToShortDateString()}");
        }

        // 5. Calculate Event Revenue
        Console.WriteLine($"\nRevenue for 'Rock Concert': ₹{eventManager.CalculateEventRevenue(1)}");
    }
}
