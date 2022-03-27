using Entities.Models;

namespace Application.Repositories;

public interface ISubForumRepo
{
    Task<ICollection<SubForum>> GetAllSubForumsAsync();
    Task<SubForum> AddSubForumAsync(SubForum subForum);
    Task<SubForum>? GetSubForumAsync(string title);

}