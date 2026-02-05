class Program
{
    static void Main()
    {
        TheaterManager manager = new TheaterManager();

        // Add Screenings
        manager.AddScreening(
            "Avengers",
            new DateTime(2026, 2, 6, 18, 0, 0),
            "Screen 1",
            100,
            250
        );

        manager.AddScreening(
            "Avengers",
            new DateTime(2026, 2, 6, 21, 0, 0),
            "Screen 2",
            80,
            300
        );

        manager.AddScreening(
            "Inception",
            new DateTime(2026, 2, 6, 19, 0, 0),
            "Screen 3",
            60,
            200
        );

        // Book Tickets
        manager.BookTickets("Avengers",
            new DateTime(2026, 2, 6, 18, 0, 0), 5);

        manager.BookTickets("Inception",
            new DateTime(2026, 2, 6, 19, 0, 0), 10);

        // Display Screenings
        Console.WriteLine("All Screenings:");
        manager.DisplayAll();

        // Revenue
        Console.WriteLine("\nTotal Revenue: ₹" +
            manager.CalculateTotalRevenue());

        // Group by Movie
        Console.WriteLine("\nGrouped By Movie:");
        var grouped = manager.GroupScreeningsByMovie();

        foreach (var movie in grouped)
        {
            Console.WriteLine(movie.Key);
            foreach (var s in movie.Value)
                Console.WriteLine($"  {s.ShowTime}");
        }

        // Available Shows
        Console.WriteLine("\nShows with 50+ seats:");
        var available = manager.GetAvailableScreenings(50);

        foreach (var s in available)
            Console.WriteLine($"{s.MovieTitle} - {s.ShowTime}");
    }
}
