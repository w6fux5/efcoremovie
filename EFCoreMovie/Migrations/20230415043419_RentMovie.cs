using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class RentMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentMovieEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentMovieEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentMovieEntity_Tbl_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Tbl_Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentMovieEntity_Tbl_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Tbl_Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentMovieEntity_MovieId",
                table: "RentMovieEntity",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_RentMovieEntity_PaymentId",
                table: "RentMovieEntity",
                column: "PaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentMovieEntity");
        }
    }
}
