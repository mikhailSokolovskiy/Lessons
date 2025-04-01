using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaloniaApplication1.DB;

public class UserConfigurator : IEntityTypeConfiguration<UserDTO>
{
    public void Configure(EntityTypeBuilder<UserDTO> builder)
    {
        builder.HasKey(x => x.Id);
    }
}