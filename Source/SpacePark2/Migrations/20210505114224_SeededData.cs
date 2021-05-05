using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark2.Migrations
{
    public partial class SeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StarShipModel",
                table: "StarShip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SpaceTraveller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ParkingHouse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity",
                table: "ParkingHouse",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "ParkingHouse",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { new Guid("3c07e5ed-a15a-46f5-a06e-2164ef7cceb0"), 4000.0, "Naboo Parking Complex" });

            migrationBuilder.InsertData(
                table: "ParkingHouse",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { new Guid("6301dd96-c3f6-43dc-9047-563c8859d1c9"), 6000.0, "Hoth SpacePort" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingHouse",
                keyColumn: "Id",
                keyValue: new Guid("3c07e5ed-a15a-46f5-a06e-2164ef7cceb0"));

            migrationBuilder.DeleteData(
                table: "ParkingHouse",
                keyColumn: "Id",
                keyValue: new Guid("6301dd96-c3f6-43dc-9047-563c8859d1c9"));

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "ParkingHouse");

            migrationBuilder.AlterColumn<string>(
                name: "StarShipModel",
                table: "StarShip",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SpaceTraveller",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ParkingHouse",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
