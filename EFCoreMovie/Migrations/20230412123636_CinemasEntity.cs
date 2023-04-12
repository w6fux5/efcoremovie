using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class CinemasEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Actorss",
                table: "Tbl_Actorss");

            migrationBuilder.RenameTable(
                name: "Tbl_Actorss",
                newName: "Tbl_Actor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Actor",
                table: "Tbl_Actor",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tbl_Cinema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    Location = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Cinema", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Cinema");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Actor",
                table: "Tbl_Actor");

            migrationBuilder.RenameTable(
                name: "Tbl_Actor",
                newName: "Tbl_Actorss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Actorss",
                table: "Tbl_Actorss",
                column: "Id");
        }
    }
}
