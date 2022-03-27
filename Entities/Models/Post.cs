namespace Entities.Models;

public class Post
{
    public string Id { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public ICollection<Vote> Votes { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public User WrittenBy { get; set; }


    public Post(string header, string body, User writtenBy)
    {
        Id = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        Header = header;
        Body = body;
        WrittenBy = writtenBy;

        Votes = new List<Vote>();
        Comments = new List<Comment>();
    }

    public short countVotes()
    {
        short total = 0;

        if (Votes.Count != 0)
        {
            foreach (var vote in Votes)
            {
                total += vote.Value;
            }

            return total;
        }
        else
        {
            return 0;
        }
    }

    public int countComments()
    {
        int total = 0;
        foreach (var comment in Comments)
        {
            total += 1;
        }

        return total;
    }
}