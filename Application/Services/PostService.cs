using Application.Repositories;
using Contracts.Services;
using Entities.Models;

namespace Application.Services;

public class PostService: IPostServices
{
    private readonly IPostRepo postRepo;

    public PostService(IPostRepo postRepo)
    {
        this.postRepo = postRepo;
    }
    
    public async Task<Post> CreatePost(Post post)
    {
        return await postRepo.CreatePost(post);
    }

    public async Task<ICollection<Post>> GetAllPostsAsync()
    {
        return await postRepo.GetAllPostsAsync();
    }

    public async Task<Post> GetPostAsync(int Id)
    {
        return await postRepo.GetPostAsync(Id);
    }

    public async Task<Post> AddComment(int Id, Comment comment)
    {
        postRepo.AddComment(Id, comment);
        return await postRepo.GetPostAsync(Id);
    }
};