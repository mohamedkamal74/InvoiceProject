using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceProject.Data.Migrations
{
    public partial class edittotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tatal",
                table: "BuyInvoices");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "BuyInvoices",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "BuyInvoices");

            migrationBuilder.AddColumn<decimal>(
                name: "Tatal",
                table: "BuyInvoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
