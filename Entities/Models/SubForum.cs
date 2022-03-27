namespace Entities.Models;

public class SubForum
{
    public User OwnedBy { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public SubForum( string title, string description,User ownedBy)
    {
        OwnedBy = ownedBy;
        Title = title;
        Description = description;
    }
}