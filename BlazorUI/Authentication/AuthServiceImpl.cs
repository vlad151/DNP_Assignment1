
using System.Security.Claims;
using System.Text.Json;
using Contracts.Services;
using Entities.Models;
using Microsoft.JSInterop;

namespace BlazorUI.Authentication;

public class AuthServiceImpl : IAuthService
{
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!; 
    private readonly IUserService userService;
    private readonly IJSRuntime jsRuntime;

    public AuthServiceImpl(IUserService userService, IJSRuntime jsRuntime)
    {
        this.userService = userService;
        this.jsRuntime = jsRuntime;
    }

    public async Task LoginAsync(string username, string password)
    {
        User? user = await userService.GetUserAsync(username); 

        ValidateLoginCredentials(password, user); 
        
        await CacheUserAsync(user!); 

        ClaimsPrincipal principal = CreateClaimsPrincipal(user); 

        OnAuthStateChanged?.Invoke(principal); 
    }

    public async Task LogoutAsync()
    {
        await ClearUserFromCacheAsync(); 
        ClaimsPrincipal principal = CreateClaimsPrincipal(null); 
        OnAuthStateChanged?.Invoke(principal); 
    }

    public async Task<ClaimsPrincipal> GetAuthAsync() 
    {
        User? user =  await GetUserFromCacheAsync();

        ClaimsPrincipal principal = CreateClaimsPrincipal(user);

        return principal;
    }

    private async Task<User?> GetUserFromCacheAsync()
    {
        string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
        if (string.IsNullOrEmpty(userAsJson)) return null;
        User user = JsonSerializer.Deserialize<User>(userAsJson)!;
        return user;
    }

    private static void ValidateLoginCredentials(string password, User? user)
    {
        if (user == null)
        {
            throw new Exception("Username not found");
        }

        if (!string.Equals(password,user.password))
        {
            throw new Exception("Password incorrect");
        }
    }

    private static ClaimsPrincipal CreateClaimsPrincipal(User? user)
    {
        if (user != null)
        {
            ClaimsIdentity identity = ConvertUserToClaimsIdentity(user);
            return new ClaimsPrincipal(identity);
        }

        return new ClaimsPrincipal();
    }

    private async Task CacheUserAsync(User user)
    {
        string serialisedData = JsonSerializer.Serialize(user);
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
    }

    private async Task ClearUserFromCacheAsync()
    {
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
    }

    private static ClaimsIdentity ConvertUserToClaimsIdentity(User user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, user.username),
            
        };

        return new ClaimsIdentity(claims, "apiauth_type");
    }
}