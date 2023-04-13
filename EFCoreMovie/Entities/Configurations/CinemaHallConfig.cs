using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class CinemaHallConfig : IEntityTypeConfiguration<CinemaHallEntity>
{
    public void Configure(EntityTypeBuilder<CinemaHallEntity> builder)
    {
        builder.Property(p => p.Cost).HasPrecision(precision: 9, scale: 2);
        builder.Property(p => p.CinemaHallType).HasDefaultValue(CinemaHallTypeEnum.TwoDimensions);
    }
}