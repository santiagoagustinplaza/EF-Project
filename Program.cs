using EFProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Create the web application builder
var builder = WebApplication.CreateBuilder(args);

// Set the switch to enable legacy timestamp behavior
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//builder.Services.AddDbContext<TasksContext> (p => p.UseInMemoryDatabase("DbTasks"));
//
// Add the Npgsql database context with the connection string from configuration
builder.Services.AddNpgsql<TasksContext>(builder.Configuration.GetConnectionString("DbTasks"));

// Build the web application
var app = builder.Build();

// Map a GET request to "/" to return the string "Hello World!"
app.MapGet("/", () => "Hello World!");

// Map a GET request to "/dbconection" to return the status of the database in memory
app.MapGet("/dbconection", ([FromServices] TasksContext dbContext) =>
{
    // Ensure the database is created
    dbContext.Database.EnsureCreated();
    return Task.FromResult(Results.Ok("Database in Memory: " + dbContext.Database.IsInMemory()));
});

// Map a GET request to "/api/tasks" to return a list of tasks with their categories
app.MapGet("/api/tasks", ([FromServices] TasksContext dbContext) =>
{
    return Task.FromResult(Results.Ok(dbContext.Tasks.Include(p => p.Category)));
});

// Map a POST request to "/api/tasks" to add a new task to the database
app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] EFProject.Models.Task task) =>
{
    // Set the task ID and creation date
    task.TaskId = Guid.NewGuid();
    task.CreationDate = DateTime.UtcNow;
    // Add the task to the database and save changes
    await dbContext.AddAsync(task);
    //await dbContext.Tasks.AddAsync(task);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

// Map a PUT request to "/api/tasks/{id}" to update a task in the database
app.MapPut("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromBody] EFProject.Models.Task task, [FromRoute] Guid id) =>
{
    // Find the current task by ID
    var currentTask = dbContext.Tasks.Find(id);
    if (currentTask != null)
    {
        // Update the task properties and save changes
        currentTask.CategoryId = task.CategoryId;
        currentTask.Title = task.Title;
        currentTask.TaskPriority = task.TaskPriority;
        currentTask.Description = task.Description;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

// Map a DELETE request to "/api/tasks/{id}" to delete a task from the database
app.MapDelete("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) =>
{
    // Find the current task by ID
    var currentTask = dbContext.Tasks.Find(id);
    if (currentTask != null)
    {
        //Delete the indicated task
        dbContext.Remove(currentTask);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

//Run the application
app.Run();
