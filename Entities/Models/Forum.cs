namespace Entities.Models;

public class Forum
{
    public ICollection<SubForum> SubForums;
    public ICollection<User> Users { get; set; }
}