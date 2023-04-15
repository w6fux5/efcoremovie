using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class CinemaConfig : IEntityTypeConfiguration<CinemaEntity>
{
    public void Configure(EntityTypeBuilder<CinemaEntity> builder)
    {
        builder.Property(p => p.Name).IsRequired();


        builder.HasOne(c => c.CinemaDetail).WithOne().HasForeignKey<CinemaDetailEntity>(cd => cd.Id);
    }
}
