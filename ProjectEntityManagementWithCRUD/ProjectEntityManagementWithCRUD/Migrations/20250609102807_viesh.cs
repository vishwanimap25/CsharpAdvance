using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEntityManagementWithCRUD.Migrations
{
    /// <inheritdoc />
    public partial class viesh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Orders",
                newName: "OrderStatus");

            migrationBuilder.AlterColumn<int>(
                name: "MobileNumber",
                table: "Users",
                type: "number(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OrderDateTime",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "orderCategory",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoryCount",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CategoryDescription",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoriesCategoryId",
                table: "Products",
                column: "CategoriesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UsersUserId",
                table: "Orders",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UsersUserId",
                table: "Categories",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UsersUserId",
                table: "Categories",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UsersUserId",
                table: "Orders",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoriesCategoryId",
                table: "Products",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UsersUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UsersUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoriesCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoriesCategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UsersUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UsersUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "orderCategory",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CategoryCount",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryDescription",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "Orders",
                newName: "MyProperty");

            migrationBuilder.AlterColumn<int>(
                name: "MobileNumber",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "number(10)");

            migrationBuilder.AlterColumn<int>(
                name: "MyProperty",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "MyProperty");
        }
    }
}
