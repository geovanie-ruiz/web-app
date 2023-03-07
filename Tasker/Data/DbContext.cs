using Microsoft.EntityFrameworkCore;

namespace Tasker;

public class ToDoListContext : DbContext
{
    public DbSet<ToDoList> ToDoLists { get; set; }
    public DbSet<Task> Tasks { get; set; }

    public ToDoListContext(DbContextOptions options) : base(options)
    {
    }
}
