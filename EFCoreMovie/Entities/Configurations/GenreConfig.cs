using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class GenreConfig : IEntityTypeConfiguration<GenreEntity>
{
    public void Configure(EntityTypeBuilder<GenreEntity> builder)
    {
        builder
            .Property(p => p.Name).IsRequired();

        builder
            .Property<DateTime>("CreatedDate")
            .HasDefaultValueSql("GetDate()")
            .HasColumnType("datetime2");


        builder.HasIndex(p => p.Name).IsUnique();
    }
}
