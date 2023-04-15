using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMovie.Migrations
{
    /// <inheritdoc />
    public partial class UserDefinedFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    CREATE FUNCTION InvoiceDetailSum (@InvoiceId INT)
                    RETURNS INT
                    AS
                    BEGIN
                        DECLARE @sum INT;
                        SELECT @sum = SUM (price) FROM Tbl_InvoiceDetail
                        WHERE InvoiceId = @invoiceId
                        RETURN @sum
                    END");


            migrationBuilder.Sql(@"
                    CREATE FUNCTION InvoiceDetailAverage (@InvoiceId INT)
                    RETURNS DECIMAL(18,2)
                    AS
                    BEGIN
                        DECLARE @average DECIMAL(18,2);
                        SELECT @average = AVG (price) FROM Tbl_InvoiceDetail
                        WHERE InvoiceId = @invoiceId
                        RETURN @average
                        END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION [dbo].[InvoiceDetailSum]");
            migrationBuilder.Sql("DROP FUNCTION [dbo].[InvoiceDetailAverage]");
        }
    }
}
