using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class SeedInvoiceId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tbl_Invoice",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Tbl_Invoice",
                columns: new[] { "Id", "CreateAt" },
                values: new object[] { 1, new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 6,
                column: "InvoiceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 7,
                column: "InvoiceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 8,
                column: "InvoiceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 9,
                column: "InvoiceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 10,
                column: "InvoiceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 11,
                column: "InvoiceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 12,
                column: "InvoiceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 13,
                column: "InvoiceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 14,
                column: "InvoiceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 15,
                column: "InvoiceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 16,
                column: "InvoiceId",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tbl_Invoice",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Tbl_Invoice",
                columns: new[] { "Id", "CreateAt" },
                values: new object[] { 5, new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 6,
                column: "InvoiceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 7,
                column: "InvoiceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 8,
                column: "InvoiceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 9,
                column: "InvoiceId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 10,
                column: "InvoiceId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 11,
                column: "InvoiceId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 12,
                column: "InvoiceId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 13,
                column: "InvoiceId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 14,
                column: "InvoiceId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 15,
                column: "InvoiceId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Tbl_InvoiceDetail",
                keyColumn: "Id",
                keyValue: 16,
                column: "InvoiceId",
                value: 5);
        }
    }
}
