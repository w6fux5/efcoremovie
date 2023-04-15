using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceAddSequence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Tbl_Invoice");

            migrationBuilder.CreateSequence<int>(
                name: "InvoiceNumber",
                schema: "Tbl_Invoice");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceNumber",
                table: "Tbl_Invoice",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR Tbl_Invoice.InvoiceNumber");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "Tbl_Invoice");

            migrationBuilder.DropSequence(
                name: "InvoiceNumber",
                schema: "Tbl_Invoice");
        }
    }
}
