using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class MovieConfig : IEntityTypeConfiguration<MovieEntity>
{
    public void Configure(EntityTypeBuilder<MovieEntity> builder)
    {
        builder.Property(p => p.Title).IsRequired().HasMaxLength(250);
        builder.Property(p => p.PosterURL).HasMaxLength(500);
    }
}
