using Application.Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DaoImpls;

public class PostDaoImpl : IPostRepo
{
    private readonly ForumContext context;


    public PostDaoImpl(ForumContext context)
    {
        this.context = context;
    }

    public async Task<Post> CreatePost(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<ICollection<Post>> GetAllPostsAsync()
    {
        ICollection<Post> posts = await context.Posts.ToListAsync();
        return posts;
    }

    public async Task<Post> GetPostAsync(string Id)
    {
        Post post = context.Posts.Find(Id);
        return post;
    }

    public async Task<Post> AddComment(string Id, Comment comment)
    {
        Post post = context.Posts.Find(Id);
        post.Comments.Add(comment);
        await context.SaveChangesAsync();
        return post;
    }

    public async void Upvote(string Id, Vote vote)
    {
        Post post = context.Posts.Find(Id);
        post.Votes.Add(vote);
        await context.SaveChangesAsync();
       
        
    }

    public async void Downvote(string Id, Vote vote)
    {
        Post post = context.Posts.Find(Id);
        post.Votes.Add(vote);
        await context.SaveChangesAsync();
    }

    
    //this method should not be used
    public async void Comment(string postId, Comment comment)
    {
        Post post = context.Posts.Find(postId);
        post.Comments.Add(comment);
        await context.SaveChangesAsync();
        
    }
}