using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations
{
    public class RentMovieConfig : IEntityTypeConfiguration<RentMovieEntity>
    {
        public void Configure(EntityTypeBuilder<RentMovieEntity> builder)
        {
        }
    }
}
