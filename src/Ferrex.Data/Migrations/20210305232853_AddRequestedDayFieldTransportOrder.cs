using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferrex.Data.Migrations
{
    public partial class AddRequestedDayFieldTransportOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TransportOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 5, 19, 28, 52, 801, DateTimeKind.Local).AddTicks(2901),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 5, 18, 37, 15, 398, DateTimeKind.Local).AddTicks(6383));

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedDay",
                table: "TransportOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 5, 19, 28, 52, 797, DateTimeKind.Local).AddTicks(2511),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 5, 18, 37, 15, 395, DateTimeKind.Local).AddTicks(1885));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedDay",
                table: "TransportOrders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "TransportOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 5, 18, 37, 15, 398, DateTimeKind.Local).AddTicks(6383),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 5, 19, 28, 52, 801, DateTimeKind.Local).AddTicks(2901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 5, 18, 37, 15, 395, DateTimeKind.Local).AddTicks(1885),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 5, 19, 28, 52, 797, DateTimeKind.Local).AddTicks(2511));
        }
    }
}
