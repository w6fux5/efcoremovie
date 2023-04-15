using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class CinemaOfferEntityOneToOneCinemaEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Cinema_Tbl_CinemaOffer_CinemaOfferId",
                table: "Tbl_Cinema");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Cinema_CinemaOfferId",
                table: "Tbl_Cinema");

            migrationBuilder.DropColumn(
                name: "CinemaOfferId",
                table: "Tbl_Cinema");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CinemaOffer_CinemaId",
                table: "Tbl_CinemaOffer",
                column: "CinemaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_CinemaOffer_Tbl_Cinema_CinemaId",
                table: "Tbl_CinemaOffer",
                column: "CinemaId",
                principalTable: "Tbl_Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_CinemaOffer_Tbl_Cinema_CinemaId",
                table: "Tbl_CinemaOffer");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_CinemaOffer_CinemaId",
                table: "Tbl_CinemaOffer");

            migrationBuilder.AddColumn<int>(
                name: "CinemaOfferId",
                table: "Tbl_Cinema",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tbl_Cinema",
                keyColumn: "Id",
                keyValue: 1,
                column: "CinemaOfferId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tbl_Cinema",
                keyColumn: "Id",
                keyValue: 2,
                column: "CinemaOfferId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tbl_Cinema",
                keyColumn: "Id",
                keyValue: 3,
                column: "CinemaOfferId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tbl_Cinema",
                keyColumn: "Id",
                keyValue: 4,
                column: "CinemaOfferId",
                value: null);

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
    }
}
