using EFCoreMovie.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<GenreEntity> Tbl_Genre { get; set; }
}
