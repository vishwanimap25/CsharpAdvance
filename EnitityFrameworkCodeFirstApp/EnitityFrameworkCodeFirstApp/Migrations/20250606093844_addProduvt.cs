using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnitityFrameworkCodeFirstApp.Migrations
{
    /// <inheritdoc />
    public partial class addProduvt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Product_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "varchar(10)", nullable: false),
                    Product_size = table.Column<string>(type: "varchar(2)", nullable: false),
                    Product_Color = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Product_no);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
