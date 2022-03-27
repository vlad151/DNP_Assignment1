using Entities.Models;

namespace Application.Repositories;

public interface IPostRepo
{
    public Task<Post> CreatePost(Post post);
    public Task<ICollection<Post>> GetAllPostsAsync();
    public Task<Post> GetPostAsync(int Id);

    public Task<Post> AddComment(int Id, Comment comment);
}