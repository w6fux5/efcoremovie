using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class CinemaDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Tbl_Cinema",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeOfConduct",
                table: "Tbl_Cinema",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "History",
                table: "Tbl_Cinema",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Missions",
                table: "Tbl_Cinema",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Values",
                table: "Tbl_Cinema",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cinema_CinemaId",
                table: "Tbl_Cinema",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Cinema_Tbl_Cinema_CinemaId",
                table: "Tbl_Cinema",
                column: "CinemaId",
                principalTable: "Tbl_Cinema",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Cinema_Tbl_Cinema_CinemaId",
                table: "Tbl_Cinema");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Cinema_CinemaId",
                table: "Tbl_Cinema");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Tbl_Cinema");

            migrationBuilder.DropColumn(
                name: "CodeOfConduct",
                table: "Tbl_Cinema");

            migrationBuilder.DropColumn(
                name: "History",
                table: "Tbl_Cinema");

            migrationBuilder.DropColumn(
                name: "Missions",
                table: "Tbl_Cinema");

            migrationBuilder.DropColumn(
                name: "Values",
                table: "Tbl_Cinema");
        }
    }
}
