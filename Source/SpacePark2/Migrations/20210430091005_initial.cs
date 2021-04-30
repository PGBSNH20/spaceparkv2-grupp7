using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePark2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingHouse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingHouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpaceTraveller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceTraveller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StarShip",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StarShipModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipLength = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarShip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParkingHouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpaceTravellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StarShipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parking_ParkingHouse_ParkingHouseId",
                        column: x => x.ParkingHouseId,
                        principalTable: "ParkingHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parking_SpaceTraveller_SpaceTravellerId",
                        column: x => x.SpaceTravellerId,
                        principalTable: "SpaceTraveller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parking_StarShip_StarShipId",
                        column: x => x.StarShipId,
                        principalTable: "StarShip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parking_ParkingHouseId",
                table: "Parking",
                column: "ParkingHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Parking_SpaceTravellerId",
                table: "Parking",
                column: "SpaceTravellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Parking_StarShipId",
                table: "Parking",
                column: "StarShipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "ParkingHouse");

            migrationBuilder.DropTable(
                name: "SpaceTraveller");

            migrationBuilder.DropTable(
                name: "StarShip");
        }
    }
}
