using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class ActorConfig : IEntityTypeConfiguration<ActorEntity>
{
    public void Configure(EntityTypeBuilder<ActorEntity> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Biography).HasColumnType("nvarchar(max)");
    }
}
