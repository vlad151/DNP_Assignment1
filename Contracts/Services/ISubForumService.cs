using Entities.Models;

namespace Contracts.Services;

public interface ISubForumService
{
    Task<ICollection<SubForum>> GetAllSubForumsAsync();
    Task<SubForum> AddSubForumAsync(SubForum subForum);
    Task<SubForum>? GetSubForumAsync(string title);


}