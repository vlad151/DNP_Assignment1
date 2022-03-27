namespace Entities.Models;

public class Comment
{
    public string Body { get; set; }
    public User WrittenBy { get; set; }

    public Comment(string body, User writtenBy)
    {
        Body = body;
        WrittenBy = writtenBy;
    }
}