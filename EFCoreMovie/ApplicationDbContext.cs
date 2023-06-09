﻿using EFCoreMovie.Entities;
using EFCoreMovie.Entities.Function;
using EFCoreMovie.Entities.Keyless;
using EFCoreMovie.Entities.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCoreMovie;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext()
    {

    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("name=DefaultConnection", options =>
            {
                options.UseNetTopologySuite();
            });
        }


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

        modelBuilder.Entity<MovieWithCount>().ToView("MovieWithCounts");

        Module3Seeding.Seed(modelBuilder);
        Module6Seeding.Seed(modelBuilder);
        Module9Seeding.Seed(modelBuilder);

        Scalars.RegisterFunctoins(modelBuilder);

        modelBuilder.HasDbFunction(() => MovieWithCountsFunc(0));

        modelBuilder.HasSequence<int>("InvoiceNumber", "Tbl_Invoice");
    }


    public IQueryable<MovieWithCount> MovieWithCountsFunc(int movieId)
    {
        return FromExpression(() => MovieWithCountsFunc(movieId));
    }


    public DbSet<GenreEntity> Tbl_Genre { get; set; }

    public DbSet<ActorEntity> Tbl_Actor { get; set; }

    public DbSet<CinemaEntity> Tbl_Cinema { get; set; }

    public DbSet<MovieEntity> Tbl_Movie { get; set; }

    public DbSet<CinemaOfferEntity> Tbl_CinemaOffer { get; set; }

    public DbSet<CinemaHallEntity> Tbl_CinemaHall { get; set; }

    public DbSet<MovieActorEntity> Tbl_MoviesActors { get; set; }

    public DbSet<LogEntity> Tbl_Log { get; set; }

    public DbSet<PersonEntity> Tbl_Person { get; set; }

    public DbSet<MessageEntity> Tbl_Message { get; set; }

    public DbSet<CinemaDetailEntity> Tbl_CinemaDetail { get; set; }

    public DbSet<PaymentEntity> Tbl_Payment { get; set; }

    public DbSet<InvoiceEntity> Tbl_Invoice { get; set; }

    public DbSet<InvoiceDetailEntity> Tbl_InvoiceDetail { get; set; }




}
