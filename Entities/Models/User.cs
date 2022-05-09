using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class User
{
    public User(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public User()
    {
        
    }
    [Key]
    public string username { get; set; }
    public string password { get; set; }
}