using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Ferrex.Data.Migrations
{
    public partial class AddDefaultValueForCreatedOnAndReviewOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewedOn",
                table: "ProductOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 3, 16, 45, 36, 565, DateTimeKind.Local).AddTicks(8722),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReviewedOn",
                table: "ProductOrders",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductOrders",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 3, 16, 45, 36, 565, DateTimeKind.Local).AddTicks(8722));
        }
    }
}
