using Entities.Models;

namespace Contracts.Services;

public interface IPostServices
{
    public Task<Post> CreatePost(Post post);
    public Task<ICollection<Post>> GetAllPostsAsync();
    public Task<Post> GetPostAsync(string Id);

    public Task<Post> AddComment(string Id, Comment comment);
    
    public void Upvote(string Id, Vote vote);

    public void Downvote(string Id, Vote vote);

    public void Comment(string postId, Comment comment);


}