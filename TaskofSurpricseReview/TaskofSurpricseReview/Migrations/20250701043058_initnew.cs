using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskofSurpricseReview.Migrations
{
    /// <inheritdoc />
    public partial class initnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "productid",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_product_OrdersId",
                table: "product",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_orders_OrdersId",
                table: "product",
                column: "OrdersId",
                principalTable: "orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_orders_OrdersId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_OrdersId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "productid",
                table: "orders");
        }
    }
}
