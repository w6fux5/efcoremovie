using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class GenreConfig : IEntityTypeConfiguration<GenreEntity>
{
    public void Configure(EntityTypeBuilder<GenreEntity> builder)
    {
        builder.ToTable(name: "Tbl_Genre", options =>
        {
            options.IsTemporal();
        });

        builder.Property("PeriodStart").HasColumnType("datetime2");
        builder.Property("PeriodEnd").HasColumnType("datetime2");


        builder.Property(p => p.Name)
            .IsRequired()
            .IsConcurrencyToken();  // Column level => 不能修改同一個 column, 但是可以同時修改一個 row 裡面不同的 column


        builder.Property(p => p.Versioin).IsRowVersion();

        builder.Property<DateTime>("CreatedDate")
            .HasDefaultValueSql("GetDate()")
            .HasColumnType("datetime2");


        builder.HasIndex(p => p.Name).IsUnique();

    }
}
