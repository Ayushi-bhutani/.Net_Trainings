using System;
using System.Collections.Generic;
using System.Linq;

public class SocialMediaManager
{
    private List<User> users = new();
    private List<Post> posts = new();

    public void RegisterUser(string userName, string bio)
    {
        users.Add(new User
        {
            UserId = Guid.NewGuid().ToString(),
            UserName = userName,
            Bio = bio
        });
    }

    public void CreatePost(string userId, string content, string type)
    {
        posts.Add(new Post
        {
            PostId = Guid.NewGuid().ToString(),
            UserId = userId,
            Content = content,
            PostType = type,
            PostTime = DateTime.Now
        });
    }

    public void LikePost(string postId, string userId)
    {
        var post = posts.FirstOrDefault(p => p.PostId == postId);
        if (post != null) post.Likes++;
    }

    public void AddComment(string postId, string userId, string comment)
    {
        var post = posts.FirstOrDefault(p => p.PostId == postId);
        if (post != null) post.Comments.Add($"{userId}: {comment}");
    }

    public Dictionary<string, List<Post>> GroupPostsByUser()
    {
        return posts.GroupBy(p => p.UserId)
                    .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Post> GetTrendingPosts(int minLikes)
    {
        return posts.Where(p => p.Likes >= minLikes)
                    .OrderByDescending(p => p.Likes).ToList();
    }
}
