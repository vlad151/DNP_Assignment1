using System.Text;
using System.Text.Json;
using Contracts.Services;
using Entities.Models;

namespace RestClient.UserClient;

public class UserHttpClient : IUserService
{
    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        using System.Net.Http.HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync("https://localhost:7075/User");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        var users = JsonSerializer.Deserialize<ICollection<User>>(content,
            new JsonSerializerOptions {PropertyNameCaseInsensitive = true})!;
        return users;
    }

    public async Task<User?> GetUserAsync(string username)
    {
        using System.Net.Http.HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7075/User/{username}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        var user = JsonSerializer.Deserialize<User>(content,
            new JsonSerializerOptions {PropertyNameCaseInsensitive = true})!;
        return user;
    }

    public async Task<User> AddUserAsync(User user)
    {
        using System.Net.Http.HttpClient client = new();
        string userAsJson = JsonSerializer.Serialize(user);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync($"https://localhost:7075/users", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        var returned = JsonSerializer.Deserialize<User>(responseContent,
            new JsonSerializerOptions {PropertyNameCaseInsensitive = true})!;

        return returned;
    }

    public async Task Update(User user)
    {
        using System.Net.Http.HttpClient client = new();
        string userAsJson = JsonSerializer.Serialize(user);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync($"https://localhost:7075/User", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
    }
}