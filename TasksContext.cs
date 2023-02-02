using efproject.Models;
using Microsoft.EntityFrameworkCore;
namespace efproject;
public class TasksContext : DbContext
{
    public DbSet<Models.Category> Categories { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Category>(category=>
        {
            category.ToTable("Category");
            category.HasKey(p=>p.CategoryId);
            category.Property(p=>p.Name).IsRequired().HasMaxLength(150);
            category.Property(p=>p.Description);
        });
        modelBuilder.Entity<Models.Task>(task=>
        {
            task.ToTable("Task");
            task.HasOne(p=>p.Category).WithMany(p=>p.Tasks).HasForeignKey(p=>p.CategoryId);
            task.Property(p=>p.Title).IsRequired().HasMaxLength(200);
            task.Property(p=>p.Description);
            task.Property(p=>p.TaskPriority);
            task.Property(p=>p.CreationDate);
            task.Ignore(p=>p.Summary);
        });
    }
}