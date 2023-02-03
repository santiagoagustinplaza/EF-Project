using EFProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//builder.Services.AddDbContext<TasksContext> (p => p.UseInMemoryDatabase("DbTasks"));
builder.Services.AddNpgsql<TasksContext> (builder.Configuration.GetConnectionString("DbTasks"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in Memory: "+ dbContext.Database.IsInMemory());
});

app.Run();
