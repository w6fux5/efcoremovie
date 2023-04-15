using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class TableValueFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                        CREATE FUNCTION MovieWithCountsFunc (@movieId INT)
                        RETURNS TABLE
                        AS
                        RETURN (
                            SELECT 
                               id, title,
                               ( SELECT COUNT(*) from GenreEntityMovieEntity WHERE MoviesId = mv.id ) AS AmountGenres,
                               ( select count(*) from Tbl_MoviesActors AS ma where ma.movieId = mv.id) AS AmountActors
                            FROM Tbl_Movie as mv
                            WHERE id = @movieId
                        )");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION MovieWithCounts");
        }
    }
}
