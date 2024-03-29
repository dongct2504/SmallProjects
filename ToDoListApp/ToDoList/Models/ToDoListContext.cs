using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models;

public class ToDoListContext : DbContext
{
    public ToDoListContext(DbContextOptions<ToDoListContext> options)
        : base(options)
    { }

    public DbSet<ToDo> ToDos { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Status> Statuses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Category>().HasData(
            new Category { CategoryId = "work", Name = "Work" },
            new Category { CategoryId = "home", Name = "Home" },
            new Category { CategoryId = "ex", Name = "Exercise" },
            new Category { CategoryId = "shop", Name = "Shopping" },
            new Category { CategoryId = "call", Name = "Contact" }
        );

        builder.Entity<Status>().HasData(
            new Status { StatusId = "open", Name = "Open" },
            new Status { StatusId = "closed", Name = "Completed" }
        );
    }
}