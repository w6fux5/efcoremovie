using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class CinemaDetailConfig : IEntityTypeConfiguration<CinemaDetailEntity>
{
    public void Configure(EntityTypeBuilder<CinemaDetailEntity> builder)
    {
        builder.ToTable("Tbl_Cinema");
    }
}
