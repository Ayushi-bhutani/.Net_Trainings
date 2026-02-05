class Program
{
    static void Main()
    {
        MusicManager mm = new MusicManager();

        // Add Songs
        mm.AddSong("Shape of You", "Ed Sheeran", "Pop",
                   "Divide", TimeSpan.FromMinutes(4));

        mm.AddSong("Believer", "Imagine Dragons", "Rock",
                   "Evolve", TimeSpan.FromMinutes(3));

        mm.AddSong("Perfect", "Ed Sheeran", "Pop",
                   "Divide", TimeSpan.FromMinutes(4));

        // Add User
        mm.AddUser("Ayushi");

        // Create Playlist
        mm.CreatePlaylist("U001", "My Favorites");

        // Add Songs to Playlist
        mm.AddSongToPlaylist("P001", "S001");
        mm.AddSongToPlaylist("P001", "S003");

        // Play Songs
        mm.PlaySong("S001");
        mm.PlaySong("S001");
        mm.PlaySong("S003");

        // Display Songs
        Console.WriteLine("All Songs:");
        mm.DisplaySongs();

        // Top Played
        Console.WriteLine("\nTop Played:");
        var top = mm.GetTopPlayedSongs(2);
        foreach (var s in top)
            Console.WriteLine($"{s.Title} - {s.PlayCount}");

        // Group by Genre
        Console.WriteLine("\nGrouped by Genre:");
        var grouped = mm.GroupSongsByGenre();
        foreach (var g in grouped)
        {
            Console.WriteLine(g.Key);
            foreach (var s in g.Value)
                Console.WriteLine($"  {s.Title}");
        }

        // Playlists
        mm.DisplayPlaylists();
    }
}
