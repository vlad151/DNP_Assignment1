using Entities.Models;

namespace Application.Repositories;

public interface IUserRepo
{
    Task<ICollection<User>> GetAllUsersAsync();
    Task<User?> GetUserAsync(string username);
    Task<User> AddUserAsync(User user);
    Task Update(User user);
    
}