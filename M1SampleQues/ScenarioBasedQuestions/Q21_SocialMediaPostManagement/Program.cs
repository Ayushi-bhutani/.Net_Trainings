using System;

class Program
{
    static void Main()
    {
        var social = new SocialMediaManager();

        // 1. Register Users
        social.RegisterUser("Alice", "Love coding");
        social.RegisterUser("Bob", "Travel enthusiast");

        var aliceId = social.GroupPostsByUser().Keys.FirstOrDefault(); // temporarily get first userId

        // 2. Create Posts
        var userId = social.GroupPostsByUser().Keys.FirstOrDefault() ?? Guid.NewGuid().ToString();
        social.CreatePost(userId, "Hello World!", "Text");
        social.CreatePost(userId, "My Vacation Photo", "Image");

        // 3. Like and Comment
        var post = social.GroupPostsByUser().Values.First()[0];
        social.LikePost(post.PostId, userId);
        social.AddComment(post.PostId, userId, "First comment!");

        // 4. Group Posts by User
        var grouped = social.GroupPostsByUser();
        Console.WriteLine("Posts by User:");
        foreach (var g in grouped)
            Console.WriteLine($"{g.Key}: {string.Join(", ", g.Value.ConvertAll(p => p.Content))}");

        // 5. Trending Posts (likes >= 1)
        var trending = social.GetTrendingPosts(1);
        Console.WriteLine("\nTrending Posts:");
        foreach (var t in trending)
            Console.WriteLine($"{t.Content}, Likes: {t.Likes}");
    }
}
