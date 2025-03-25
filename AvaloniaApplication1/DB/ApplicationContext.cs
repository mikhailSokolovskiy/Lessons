using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.DB;

public class ApplicationContext : DbContext
{
    public DbSet<TaskDTO> Tasks => Set<TaskDTO>();
    public ApplicationContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tasks1.db");
    }
}