using AvaloniaApplication1.Models;
using AvaloniaApplication1.Service;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.DB;

public class ApplicationContext : DbContext
{
    public DbSet<TaskDTO> Tasks => Set<TaskDTO>();
    public DbSet<UserDTO> Users => Set<UserDTO>();
    public ApplicationContext() => Database.EnsureCreated();
    private readonly IConfigService _cfg;

    public ApplicationContext(IConfigService cfg)
    {
        _cfg = cfg;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_cfg.GetConnectionString());
    }
}