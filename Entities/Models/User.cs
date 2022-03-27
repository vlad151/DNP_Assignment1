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
    public string username { get; set; }
    public string password { get; set; }
}