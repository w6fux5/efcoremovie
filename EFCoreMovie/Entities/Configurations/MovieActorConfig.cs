using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovie.Entities.Configurations;

public class MovieActorConfig : IEntityTypeConfiguration<MovieActorEntity>
{
    public void Configure(EntityTypeBuilder<MovieActorEntity> builder)
    {
        builder.HasKey(p => new { p.MovieId, p.ActorId });
    }
}
