using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactiveUI;

namespace AvaloniaApplication1.DB;

public class TaskConfigurator : IEntityTypeConfiguration<TaskDTO>
{
    public void Configure(EntityTypeBuilder<TaskDTO> builder)
    {
        builder.HasKey(x => x.Id);
    }
}