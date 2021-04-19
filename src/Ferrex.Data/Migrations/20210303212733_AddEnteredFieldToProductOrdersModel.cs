using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferrex.Data.Migrations
{
    public partial class AddEnteredFieldToProductOrdersModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 3, 17, 27, 32, 638, DateTimeKind.Local).AddTicks(8317),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 3, 16, 45, 36, 565, DateTimeKind.Local).AddTicks(8722));

            migrationBuilder.AddColumn<bool>(
                name: "Entered",
                table: "ProductOrders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entered",
                table: "ProductOrders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 3, 16, 45, 36, 565, DateTimeKind.Local).AddTicks(8722),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 3, 17, 27, 32, 638, DateTimeKind.Local).AddTicks(8317));
        }
    }
}
