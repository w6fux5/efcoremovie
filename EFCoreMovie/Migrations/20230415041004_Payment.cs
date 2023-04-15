﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class Payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    Last4Digits = table.Column<string>(type: "char(150)", maxLength: 150, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Payment", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tbl_Payment",
                columns: new[] { "Id", "Amount", "EmailAddress", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { 1, 10m, "test@example.com", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 110m, "cool@example.com", new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Tbl_Payment",
                columns: new[] { "Id", "Amount", "Last4Digits", "PaymentDate", "PaymentType" },
                values: new object[,]
                {
                    { 3, 99m, "1234", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 22m, "9876", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Payment");
        }
    }
}
