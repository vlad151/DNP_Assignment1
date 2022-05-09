using Application.Repositories;
using Application.Services;
using Contracts.Services;
using EFCDataAccess.DaoImpls;
using JsonDataAccess.Context;
using JsonDataAccess.RepoImpls;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserDaoImpl>();
builder.Services.AddScoped<IPostServices, PostService>();
builder.Services.AddScoped<IPostRepo, PostDaoImpl>();
builder.Services.AddScoped<JsonContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();