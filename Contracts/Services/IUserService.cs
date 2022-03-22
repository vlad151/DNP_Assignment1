using Entities.Models;

namespace Contracts.Services;

public interface IUserService
{
    public Task<User> GetUserAsync(string username);
}