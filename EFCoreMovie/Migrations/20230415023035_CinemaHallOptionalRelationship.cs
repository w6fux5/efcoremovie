using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class CinemaHallOptionalRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_CinemaHall_Tbl_Cinema_CinemaId",
                table: "Tbl_CinemaHall");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Tbl_CinemaHall",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_CinemaHall_Tbl_Cinema_CinemaId",
                table: "Tbl_CinemaHall",
                column: "CinemaId",
                principalTable: "Tbl_Cinema",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_CinemaHall_Tbl_Cinema_CinemaId",
                table: "Tbl_CinemaHall");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Tbl_CinemaHall",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_CinemaHall_Tbl_Cinema_CinemaId",
                table: "Tbl_CinemaHall",
                column: "CinemaId",
                principalTable: "Tbl_Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
