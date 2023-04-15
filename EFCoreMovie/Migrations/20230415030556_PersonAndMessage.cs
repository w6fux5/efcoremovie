using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class PersonAndMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Message_Tbl_Person_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Tbl_Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Message_Tbl_Person_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Tbl_Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tbl_Person",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mike" },
                    { 2, "Andy" }
                });

            migrationBuilder.InsertData(
                table: "Tbl_Message",
                columns: new[] { "Id", "Content", "ReceiverId", "SenderId" },
                values: new object[,]
                {
                    { 1, "Hi, Andy!", 2, 1 },
                    { 2, "Hey Mike, how are your!", 1, 2 },
                    { 3, "All good, and you!", 2, 1 },
                    { 4, "Very good :)", 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Message_ReceiverId",
                table: "Tbl_Message",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Message_SenderId",
                table: "Tbl_Message",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Message");

            migrationBuilder.DropTable(
                name: "Tbl_Person");
        }
    }
}
