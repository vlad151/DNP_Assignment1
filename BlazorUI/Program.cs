using Application.Repositories;
using BlazorUI.Authentication;
using Contracts.Services;
using Application.Services;
using Entities.Models;
using JsonDataAccess.Context;
using JsonDataAccess.RepoImpls;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using RestClient.PostClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<JsonContext>();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthServiceImpl>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, JsonUserRepo>();
builder.Services.AddScoped<ISubForumRepo, JsonSubForumRepo>();
builder.Services.AddScoped<ISubForumService, SubForumService>();
builder.Services.AddScoped<IPostRepo, JsonPostRepo>();
builder.Services.AddScoped<IPostServices, PostService>();
builder.Services.AddScoped<IPostServices, PostHttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();