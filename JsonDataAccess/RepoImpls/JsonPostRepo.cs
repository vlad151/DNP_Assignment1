using Application.Repositories;
using Entities.Models;
using JsonDataAccess.Context;

namespace JsonDataAccess.RepoImpls;

public class JsonPostRepo :IPostRepo
{

    private JsonContext jsonContext;


    public JsonPostRepo(JsonContext jsonContext)
    {
        this.jsonContext = jsonContext;
    }
    public async Task<Post> CreatePost(Post post)
    {
        jsonContext.Forum.Posts.Add(post);
        await jsonContext.SaveChangesAsync();
        return post;
    }

    public async Task<ICollection<Post>> GetAllPostsAsync()
    {
      return await Task.FromResult(jsonContext.Forum.Posts);
    }

    public async Task<Post> GetPostAsync(int Id)
    {
      return jsonContext.Forum.Posts.FirstOrDefault(p => Id.Equals(p.Id));
    }

    public async Task<Post> AddComment(int Id, Comment comment)
    {
        Post? post = GetPostAsync(Id).Result;
        if (post != null)
        {
            post.Comments.Add(comment);
            await jsonContext.SaveChangesAsync();
        }

        return null;
    }
}