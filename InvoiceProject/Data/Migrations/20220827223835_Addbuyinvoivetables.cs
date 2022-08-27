using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceProject.Data.Migrations
{
    public partial class Addbuyinvoivetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyInvoices",
                columns: table => new
                {
                    BuyInvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(nullable: false),
                    CurrentState = table.Column<int>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeleteUserId = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    SupplierId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Tatal = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    AfterDiscount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyInvoices", x => x.BuyInvoiceId);
                    table.ForeignKey(
                        name: "FK_BuyInvoices_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyInvoices_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BuyInvoiceItems",
                columns: table => new
                {
                    BuyInvoiceItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Tatal = table.Column<decimal>(nullable: false),
                    BuyInvoiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyInvoiceItems", x => x.BuyInvoiceItemId);
                    table.ForeignKey(
                        name: "FK_BuyInvoiceItems_BuyInvoices_BuyInvoiceId",
                        column: x => x.BuyInvoiceId,
                        principalTable: "BuyInvoices",
                        principalColumn: "BuyInvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyInvoiceItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuyInvoiceItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyInvoiceItems_BuyInvoiceId",
                table: "BuyInvoiceItems",
                column: "BuyInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyInvoiceItems_CategoryId",
                table: "BuyInvoiceItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyInvoiceItems_ProductId",
                table: "BuyInvoiceItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyInvoices_BranchId",
                table: "BuyInvoices",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyInvoices_SupplierId",
                table: "BuyInvoices",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyInvoiceItems");

            migrationBuilder.DropTable(
                name: "BuyInvoices");
        }
    }
}
