using System;
using System.Collections.Generic;
using System.Linq;

public class MusicManager
{
    private List<Song> songs = new();
    private List<User> users = new();
    private List<Playlist> playlists = new();

    private int songCounter = 1;
    private int playlistCounter = 1;
    private int userCounter = 1;

    // Add Song
    public void AddSong(string title, string artist, string genre,
                        string album, TimeSpan duration)
    {
        songs.Add(new Song
        {
            SongId = $"S{songCounter++:000}",
            Title = title,
            Artist = artist,
            Genre = genre,
            Album = album,
            Duration = duration,
            PlayCount = 0
        });
    }

    // Register User
    public void AddUser(string userName)
    {
        users.Add(new User
        {
            UserId = $"U{userCounter++:000}",
            UserName = userName
        });
    }

    // Create Playlist
    public void CreatePlaylist(string userId, string playlistName)
    {
        var user = users.FirstOrDefault(u => u.UserId == userId);
        if (user == null)
            throw new Exception("User not found");

        var playlist = new Playlist
        {
            PlaylistId = $"P{playlistCounter++:000}",
            Name = playlistName,
            CreatedBy = userId
        };

        playlists.Add(playlist);
        user.UserPlaylists.Add(playlist);
    }

    // Add Song to Playlist
    public bool AddSongToPlaylist(string playlistId, string songId)
    {
        var playlist = playlists.FirstOrDefault(p => p.PlaylistId == playlistId);
        var song = songs.FirstOrDefault(s => s.SongId == songId);

        if (playlist == null || song == null)
            return false;

        playlist.Songs.Add(song);
        return true;
    }

    // Play Song (Increase PlayCount)
    public void PlaySong(string songId)
    {
        var song = songs.FirstOrDefault(s => s.SongId == songId);
        if (song != null)
            song.PlayCount++;
    }

    // Group Songs by Genre
    public Dictionary<string, List<Song>> GroupSongsByGenre()
    {
        return songs
            .GroupBy(s => s.Genre)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Top Played Songs
    public List<Song> GetTopPlayedSongs(int count)
    {
        return songs
            .OrderByDescending(s => s.PlayCount)
            .Take(count)
            .ToList();
    }

    // Helper Displays
    public void DisplaySongs()
    {
        foreach (var s in songs)
            Console.WriteLine($"{s.SongId} - {s.Title} ({s.PlayCount} plays)");
    }

    public void DisplayPlaylists()
    {
        foreach (var p in playlists)
        {
            Console.WriteLine($"\nPlaylist: {p.Name}");
            foreach (var s in p.Songs)
                Console.WriteLine($"  {s.Title}");
        }
    }
}
