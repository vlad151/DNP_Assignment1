using Entities.Models;

namespace Contracts.Services.Impls;

public class InMemoryUserService : IUserService
{
    public async Task<User?> GetUserAsync(string username)
    {
        User? find = users.Find(user => user.username.Equals(username));
        return find;
    }

    private List<User> users = new()
    {
        new User("vlad1234", "vlad4321")
    };
}