using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCDataAccess;

public class ForumContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source= C:\Users\lazar\RiderProjects\DNP_Assignment1\EFCDataAccess\Reddit.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u=> u.username);
        modelBuilder.Entity<Post>().HasKey(p=>p.Id);
    }
}