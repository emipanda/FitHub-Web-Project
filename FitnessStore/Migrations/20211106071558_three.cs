using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessStore.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Product_ProductId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_ProductId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Supplier");

            migrationBuilder.AddColumn<int>(
                name: "ProductSuppliersId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductSuppliersId",
                table: "Product",
                column: "ProductSuppliersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_ProductSuppliersId",
                table: "Product",
                column: "ProductSuppliersId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_ProductSuppliersId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductSuppliersId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductSuppliersId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ProductId",
                table: "Supplier",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Product_ProductId",
                table: "Supplier",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
