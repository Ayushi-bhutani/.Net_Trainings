using System;
using System.Collections.Generic;
using System.Linq;

public class EventManager
{
    private List<Event> events = new();
    private List<Attendee> attendees = new();
    private List<Ticket> tickets = new();
    private int eventCounter = 1;

    public void CreateEvent(string name, string type, DateTime date,
                            string venue, int capacity, double price)
    {
        events.Add(new Event
        {
            EventId = eventCounter++,
            EventName = name,
            EventType = type,
            EventDate = date,
            Venue = venue,
            TotalCapacity = capacity,
            TicketsSold = 0,
            TicketPrice = price
        });
    }

    public bool BookTicket(int eventId, int attendeeId, string seatNumber)
    {
        var ev = events.FirstOrDefault(e => e.EventId == eventId);
        if (ev == null || ev.TicketsSold >= ev.TotalCapacity) return false;

        tickets.Add(new Ticket
        {
            TicketNumber = Guid.NewGuid().ToString(),
            EventId = eventId,
            AttendeeId = attendeeId,
            PurchaseDate = DateTime.Now,
            SeatNumber = seatNumber
        });

        ev.TicketsSold++;
        return true;
    }

    public Dictionary<string, List<Event>> GroupEventsByType()
    {
        return events.GroupBy(e => e.EventType)
                     .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Event> GetUpcomingEvents(int days)
    {
        var target = DateTime.Now.AddDays(days);
        return events.Where(e => e.EventDate <= target && e.EventDate >= DateTime.Now)
                     .OrderBy(e => e.EventDate).ToList();
    }

    public double CalculateEventRevenue(int eventId)
    {
        var ev = events.FirstOrDefault(e => e.EventId == eventId);
        return ev != null ? ev.TicketsSold * ev.TicketPrice : 0;
    }
}
