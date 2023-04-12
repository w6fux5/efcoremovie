using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class CinemaOfferEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaOfferId",
                table: "Tbl_Cinema",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tbl_CinemaOffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Begin = table.Column<DateTime>(type: "date", nullable: false),
                    End = table.Column<DateTime>(type: "date", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CinemaOffer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cinema_CinemaOfferId",
                table: "Tbl_Cinema",
                column: "CinemaOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Cinema_Tbl_CinemaOffer_CinemaOfferId",
                table: "Tbl_Cinema",
                column: "CinemaOfferId",
                principalTable: "Tbl_CinemaOffer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Cinema_Tbl_CinemaOffer_CinemaOfferId",
                table: "Tbl_Cinema");

            migrationBuilder.DropTable(
                name: "Tbl_CinemaOffer");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Cinema_CinemaOfferId",
                table: "Tbl_Cinema");

            migrationBuilder.DropColumn(
                name: "CinemaOfferId",
                table: "Tbl_Cinema");
        }
    }
}
