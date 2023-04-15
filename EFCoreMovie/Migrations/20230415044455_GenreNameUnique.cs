using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class GenreNameUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Genre_Name",
                table: "Tbl_Genre",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tbl_Genre_Name",
                table: "Tbl_Genre");
        }
    }
}
