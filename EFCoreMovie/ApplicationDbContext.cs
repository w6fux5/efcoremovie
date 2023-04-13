using EFCoreMovie.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCoreMovie;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("date");  //修改 sql server 中, DateTime 的預設類型 (原本預設類型為 datetime2, 更改為 date)
        configurationBuilder.Properties<string>().HaveMaxLength(150);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<GenreEntity> Tbl_Genre { get; set; }

    public DbSet<ActorEntity> Tbl_Actor { get; set; }

    public DbSet<CinemaEntity> Tbl_Cinema { get; set; }

    public DbSet<MovieEntity> Tbl_Movie { get; set; }
    public DbSet<CinemaOfferEntity> Tbl_CinemaOffer { get; set; }

    public DbSet<CinemaHallEntity> Tbl_CinemaHall { get; set; }

    public DbSet<MovieActorEntity> Tbl_MoviesActors { get; set; }
}
