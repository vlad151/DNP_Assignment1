using Application.Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DaoImpls;

public class UserDaoImpl :IUserRepo
{

    private readonly ForumContext context;

    public UserDaoImpl(ForumContext context)
    {
        this.context = context;
    }
    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        ICollection<User> users = await context.Users.ToListAsync();
        return users;
    }

    public async Task<User?> GetUserAsync(string username)
    {
       User user = context.Users.Find(username);
       return user;
    }

    public async Task<User> AddUserAsync(User user)
    {
        EntityEntry<User> added = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public Task Update(User user)
    {
        context.Users.Update(user);
        return context.SaveChangesAsync();
    }
}