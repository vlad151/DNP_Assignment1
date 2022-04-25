using System.Text;
using System.Text.Json;
using Contracts.Services;
using Entities.Models;

namespace RestClient.PostClient;

public class PostHttpClient : IPostServices

{
    public async Task<Post> CreatePost(Post post)
    {
        using HttpClient client = new();

        string postAsJson = JsonSerializer.Serialize(post);

        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://localhost:7075/Post", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($" Error: {response.StatusCode}, {response.Content}");
        }

        Post returned = JsonSerializer.Deserialize<Post>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return returned;
    }

    public async Task<ICollection<Post>> GetAllPostsAsync()
    {
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync("https://localhost:7075/Post");
        string content= await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content,new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task<Post> GetPostAsync(string Id)
    {
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7075/{Id}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        var post = JsonSerializer.Deserialize<Post>(content,
            new JsonSerializerOptions {PropertyNameCaseInsensitive = true})!;

        return post;
    }

    public async Task AddComment(string Id, Comment comment)
    {
        using HttpClient client = new();
        string postAsJson = JsonSerializer.Serialize(comment);
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync($"https://localhost:7075/{Id}/comments", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
    }

    public async void Upvote(string Id, Vote vote)
    {
        using HttpClient client = new();
        string postAsJson = JsonSerializer.Serialize(vote);
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync($"https://localhost:7075//{Id}/votes", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
    }

    public async void Downvote(string Id, Vote vote)
    {
        using HttpClient client = new();
        string postAsJson = JsonSerializer.Serialize(vote);
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync($"https://localhost:7075/{Id}/downvotes", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
    }
}