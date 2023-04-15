using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class ViewMovieCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW dbo.MovieWithCounts AS 
                                    SELECT 
                                    id, title,
                                    ( SELECT COUNT(*) from GenreEntityMovieEntity WHERE MoviesId = mv.id ) AS AmountGenres,
                                    ( select count(*) from Tbl_MoviesActors AS ma where ma.movieId = mv.id) AS AmountActors
                                    FROM Tbl_Movie as mv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.MovieWithCounts");
        }
    }
}
