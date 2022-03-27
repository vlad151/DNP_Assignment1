using Application.Repositories;
using Contracts.Services;
using Entities.Models;

namespace Application.Services;

public class SubForumService:ISubForumService
{

    private readonly ISubForumRepo subForumRepo;

    public SubForumService(ISubForumRepo subForumRepo)
    {
        this.subForumRepo = subForumRepo;
    }
    public async Task<ICollection<SubForum>> GetAllSubForumsAsync()
    {
        return await subForumRepo.GetAllSubForumsAsync();
    }

    public async Task<SubForum> AddSubForumAsync(SubForum subForum)
    {
        return await subForumRepo.AddSubForumAsync(subForum);
    }

    public async Task<SubForum>? GetSubForumAsync(string title)
    {
        return await subForumRepo.GetSubForumAsync(title);
    }
}