
using Application.Repositories;
using Contracts.Services;
using Entities.Models;

namespace Application.Services;

public class UserService :IUserService
{
    private readonly IUserRepo userRepo;


    public UserService(IUserRepo userRepo)
    {
        this.userRepo = userRepo;
    }

    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        return await userRepo.GetAllUsersAsync();
    }
    public async Task<User?> GetUserAsync(string username)
    {
        return await userRepo.GetUserAsync(username);
    }
    public async Task<User> AddUserAsync(User user)
    {
        return await userRepo.AddUserAsync(user);
    }

    public async Task Update(User user)
    {
        await userRepo.Update(user);
    }
    
}