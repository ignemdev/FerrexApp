using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferrex.Data.Migrations
{
    public partial class RemoveEnteredFieldTransportOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entered",
                table: "TransportOrders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TransportOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 5, 18, 37, 15, 398, DateTimeKind.Local).AddTicks(6383),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 5, 17, 23, 14, 878, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 5, 18, 37, 15, 395, DateTimeKind.Local).AddTicks(1885),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 5, 17, 23, 14, 874, DateTimeKind.Local).AddTicks(8042));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TransportOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 5, 17, 23, 14, 878, DateTimeKind.Local).AddTicks(6763),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 5, 18, 37, 15, 398, DateTimeKind.Local).AddTicks(6383));

            migrationBuilder.AddColumn<bool>(
                name: "Entered",
                table: "TransportOrders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 5, 17, 23, 14, 874, DateTimeKind.Local).AddTicks(8042),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 5, 18, 37, 15, 395, DateTimeKind.Local).AddTicks(1885));
        }
    }
}
