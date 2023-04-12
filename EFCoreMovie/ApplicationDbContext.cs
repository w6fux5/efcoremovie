using EFCoreMovie.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<GenreEntity> Tbl_Genre { get; set; }

    public DbSet<ActorEntity> Tbl_Actor { get; set; }

    public DbSet<CinemaEntity> Tbl_Cinema { get; set; }

    public DbSet<MovieEntity> Tbl_Movie { get; set; }
    public DbSet<CinemaOfferEntity> Tbl_CinemaOffer { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GenreEntity>().Property(p => p.Name).IsRequired().HasMaxLength(150);

        modelBuilder.Entity<ActorEntity>().Property(p => p.Name).IsRequired().HasMaxLength(150);
        modelBuilder.Entity<ActorEntity>().Property(p => p.DateOfBirth).HasColumnType("date");


        modelBuilder.Entity<CinemaEntity>().Property(p => p.Name).IsRequired().HasMaxLength(150);
        modelBuilder.Entity<CinemaEntity>().Property(p => p.Price).HasPrecision(precision: 9, scale: 2);

        modelBuilder.Entity<MovieEntity>().Property(p => p.Title).IsRequired().HasMaxLength(250);
        modelBuilder.Entity<MovieEntity>().Property(p => p.ReleaseDate).HasColumnType("date");
        modelBuilder.Entity<MovieEntity>().Property(p => p.PosterURL).HasMaxLength(500);

        modelBuilder.Entity<CinemaOfferEntity>().Property(p => p.DiscountPercentage).HasPrecision(5, 2);
        modelBuilder.Entity<CinemaOfferEntity>().Property(p => p.Begin).HasColumnType("date");
        modelBuilder.Entity<CinemaOfferEntity>().Property(p => p.End).HasColumnType("date");


    }
}
