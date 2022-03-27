namespace Entities.Models;

public class Forum  
{
    public ICollection<SubForum> SubForums;
    public ICollection<User> Users { get; set; }
    
    public ICollection<Post> Posts { get; set; }

    public Forum()
    {
        Users = new List<User>();
        Posts = new List<Post>();
    }
}