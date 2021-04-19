using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferrex.Data.Migrations
{
    public partial class ProductImageFieldDropped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
