using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark2.Migrations
{
    public partial class SeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkingHouse",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("662c03dc-52c6-44dc-9860-df1b865ef8ce"), "Naboo Parking Complex" });

            migrationBuilder.InsertData(
                table: "ParkingHouse",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2cfd2095-60d5-4301-8deb-e6df6850105e"), "Hoth SpacePort" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingHouse",
                keyColumn: "Id",
                keyValue: new Guid("2cfd2095-60d5-4301-8deb-e6df6850105e"));

            migrationBuilder.DeleteData(
                table: "ParkingHouse",
                keyColumn: "Id",
                keyValue: new Guid("662c03dc-52c6-44dc-9860-df1b865ef8ce"));
        }
    }
}
