using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.DataAccess.Migrations.Spa
{
    /// <inheritdoc />
    public partial class InitialSpa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpaSalons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaSalons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpaBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SpaSalonId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpaSalonDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaBookings_SpaSalons_SpaSalonDataId",
                        column: x => x.SpaSalonDataId,
                        principalTable: "SpaSalons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpaBookings_SpaSalons_SpaSalonId",
                        column: x => x.SpaSalonId,
                        principalTable: "SpaSalons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpaServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpaSalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaServices_SpaSalons_SpaSalonId",
                        column: x => x.SpaSalonId,
                        principalTable: "SpaSalons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpaServiceImgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpaServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaServiceImgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaServiceImgs_SpaServices_SpaServiceId",
                        column: x => x.SpaServiceId,
                        principalTable: "SpaServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpaBookings_SpaSalonDataId",
                table: "SpaBookings",
                column: "SpaSalonDataId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaBookings_SpaSalonId",
                table: "SpaBookings",
                column: "SpaSalonId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaServiceImgs_SpaServiceId",
                table: "SpaServiceImgs",
                column: "SpaServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaServices_SpaSalonId",
                table: "SpaServices",
                column: "SpaSalonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpaBookings");

            migrationBuilder.DropTable(
                name: "SpaServiceImgs");

            migrationBuilder.DropTable(
                name: "SpaServices");

            migrationBuilder.DropTable(
                name: "SpaSalons");
        }
    }
}
