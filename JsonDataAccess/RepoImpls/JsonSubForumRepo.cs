using Application.Repositories;
using Entities.Models;
using JsonDataAccess.Context;

namespace JsonDataAccess.RepoImpls;

public class JsonSubForumRepo :ISubForumRepo
{
    public JsonContext jsonContext;

    public JsonSubForumRepo(JsonContext jsonContext)
    {
        this.jsonContext = jsonContext;
    }
    public async Task<ICollection<SubForum>> GetAllSubForumsAsync()
    {
        return await Task.FromResult(jsonContext.Forum.SubForums);
    }

    public async Task<SubForum> AddSubForumAsync(SubForum subForum)
    {
        jsonContext.Forum.SubForums.Add(subForum);
        await jsonContext.SaveChangesAsync();
        return subForum;
    }

    public  Task<SubForum>? GetSubForumAsync(string title)
    {
        SubForum? subForum = jsonContext.Forum.SubForums.FirstOrDefault(s => title.Equals(s.Title));
        return Task.FromResult(subForum);
    }
}