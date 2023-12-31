using Microsoft.EntityFrameworkCore;

namespace Apiapp.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options): base(options)
    {
    }

    public DbSet<Ratings> TodoItems { get; set; } 
}