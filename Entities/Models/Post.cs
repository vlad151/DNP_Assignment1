namespace Entities.Models;

public class Post
{
    public string Id { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public ICollection<Vote> Votes { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public User WrittenBy { get; set; }

    public Post(string id, string header, string body, ICollection<Vote> votes, ICollection<Comment> comments, User writtenBy)
    {
        Id = id;
        Header = header;
        Body = body;
        Votes = votes;
        Comments = comments;
        WrittenBy = writtenBy;
    }
    
}
