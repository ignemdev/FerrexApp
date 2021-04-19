using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Ferrex.Data.Migrations
{
    public partial class AddTransportOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 5, 17, 23, 14, 874, DateTimeKind.Local).AddTicks(8042),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 3, 17, 27, 32, 638, DateTimeKind.Local).AddTicks(8317));

            migrationBuilder.CreateTable(
                name: "TransportOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2021, 3, 5, 17, 23, 14, 878, DateTimeKind.Local).AddTicks(6763)),
                    OrderNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    TruckDescription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    RequestedKilometers = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "double", nullable: false),
                    Comment = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Accepted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Entered = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ReviewedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportOrders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportOrders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 3, 17, 27, 32, 638, DateTimeKind.Local).AddTicks(8317),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 3, 5, 17, 23, 14, 874, DateTimeKind.Local).AddTicks(8042));
        }
    }
}
