using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test1.Migrations
{
    public partial class Test2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityDict",
                columns: table => new
                {
                    IdCityDict = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityDict", x => x.IdCityDict);
                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    IdPassenger = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PassportNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.IdPassenger);
                });

            migrationBuilder.CreateTable(
                name: "Plane",
                columns: table => new
                {
                    IdPlane = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plane", x => x.IdPlane);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    IdFlight = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdPlane = table.Column<int>(type: "int", nullable: false),
                    IdCityDict = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.IdFlight);
                    table.ForeignKey(
                        name: "FK_Flight_CityDict_IdCityDict",
                        column: x => x.IdCityDict,
                        principalTable: "CityDict",
                        principalColumn: "IdCityDict",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_Plane_IdPlane",
                        column: x => x.IdPlane,
                        principalTable: "Plane",
                        principalColumn: "IdPlane",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightPassenger",
                columns: table => new
                {
                    IdFlight = table.Column<int>(type: "int", nullable: false),
                    IdPassenger = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Flight_Passenger_PK", x => new { x.IdFlight, x.IdPassenger });
                    table.ForeignKey(
                        name: "FK_FlightPassenger_Flight_IdFlight",
                        column: x => x.IdFlight,
                        principalTable: "Flight",
                        principalColumn: "IdFlight",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightPassenger_Passenger_IdPassenger",
                        column: x => x.IdPassenger,
                        principalTable: "Passenger",
                        principalColumn: "IdPassenger",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CityDict",
                columns: new[] { "IdCityDict", "City" },
                values: new object[,]
                {
                    { 1, "cityName1" },
                    { 2, "cityName2" },
                    { 3, "cityName3" }
                });

            migrationBuilder.InsertData(
                table: "Passenger",
                columns: new[] { "IdPassenger", "FirstName", "LastName", "PassportNum" },
                values: new object[,]
                {
                    { 1, "firstName1", "lastName1", "11111111111" },
                    { 2, "firstName2", "lastName2", "2222222222222" },
                    { 3, "firstName3", "lastName3", "3333333333" }
                });

            migrationBuilder.InsertData(
                table: "Plane",
                columns: new[] { "IdPlane", "MaxSeats", "Name" },
                values: new object[,]
                {
                    { 1, 50, "planeName1" },
                    { 2, 30, "planeName2" },
                    { 3, 60, "planeName3" }
                });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "IdFlight", "Comments", "FlightDate", "IdCityDict", "IdPlane" },
                values: new object[] { 1, "comments1", new DateTime(2021, 5, 13, 10, 58, 13, 610, DateTimeKind.Local).AddTicks(4079), 1, 1 });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "IdFlight", "Comments", "FlightDate", "IdCityDict", "IdPlane" },
                values: new object[] { 2, "comments2", new DateTime(2021, 5, 23, 10, 58, 13, 612, DateTimeKind.Local).AddTicks(5817), 2, 2 });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "IdFlight", "Comments", "FlightDate", "IdCityDict", "IdPlane" },
                values: new object[] { 3, "comments3", new DateTime(2021, 6, 2, 10, 58, 13, 612, DateTimeKind.Local).AddTicks(5860), 3, 3 });

            migrationBuilder.InsertData(
                table: "FlightPassenger",
                columns: new[] { "IdFlight", "IdPassenger" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "FlightPassenger",
                columns: new[] { "IdFlight", "IdPassenger" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "FlightPassenger",
                columns: new[] { "IdFlight", "IdPassenger" },
                values: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_IdCityDict",
                table: "Flight",
                column: "IdCityDict");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_IdPlane",
                table: "Flight",
                column: "IdPlane");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_IdPassenger",
                table: "FlightPassenger",
                column: "IdPassenger");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightPassenger");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.DropTable(
                name: "CityDict");

            migrationBuilder.DropTable(
                name: "Plane");
        }
    }
}
