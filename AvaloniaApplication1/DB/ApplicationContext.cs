using AvaloniaApplication1.Models;
using AvaloniaApplication1.Service;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.DB;

public class ApplicationContext : DbContext
{
    public DbSet<TaskDTO> Tasks => Set<TaskDTO>();
    public DbSet<UserDTO> Users => Set<UserDTO>();
    private readonly IConfigService _cfg;

    public ApplicationContext(IConfigService cfg)
    {
        _cfg = cfg;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new TaskConfigurator());
        modelBuilder.ApplyConfiguration(new UserConfigurator());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_cfg.GetConnectionString());
    }
}