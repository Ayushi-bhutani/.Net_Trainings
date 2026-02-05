public class TheaterManager
{
    private List<MovieScreening> screenings = new List<MovieScreening>();

    // Add Screening
    public void AddScreening(string title, DateTime time,
                             string screen, int seats, double price)
    {
        screenings.Add(new MovieScreening
        {
            MovieTitle = title,
            ShowTime = time,
            ScreenNumber = screen,
            TotalSeats = seats,
            TicketPrice = price,
            BookedSeats = 0
        });
    }

    // Book Tickets
    public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
    {
        var screening = screenings.FirstOrDefault(s =>
            s.MovieTitle.Equals(movieTitle, StringComparison.OrdinalIgnoreCase)
            && s.ShowTime == showTime);

        if (screening == null)
        {
            Console.WriteLine("Screening not found.");
            return false;
        }

        if (screening.AvailableSeats < tickets)
        {
            Console.WriteLine("Not enough seats available.");
            return false;
        }

        screening.BookedSeats += tickets;
        return true;
    }

    // Group by Movie
    public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
    {
        return screenings
            .GroupBy(s => s.MovieTitle)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Total Revenue
    public double CalculateTotalRevenue()
    {
        return screenings.Sum(s => s.Revenue);
    }

    // Available Screenings
    public List<MovieScreening> GetAvailableScreenings(int minSeats)
    {
        return screenings
            .Where(s => s.AvailableSeats >= minSeats)
            .ToList();
    }

    // Display Helper
    public void DisplayAll()
    {
        foreach (var s in screenings)
        {
            Console.WriteLine(
                $"{s.MovieTitle} | {s.ShowTime} | Screen {s.ScreenNumber} | " +
                $"Available: {s.AvailableSeats}");
        }
    }
}
