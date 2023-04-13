using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class CinemaOffeConfig : IEntityTypeConfiguration<CinemaOfferEntity>
{
    public void Configure(EntityTypeBuilder<CinemaOfferEntity> builder)
    {
        builder.Property(p => p.DiscountPercentage).HasPrecision(5, 2);
    }
}
