using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _20260611_0955AddTourBookingFieldsTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartureCity",
                table: "TourBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "TourBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Guests",
                table: "TourBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "TourBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureCity",
                table: "TourBookings");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "TourBookings");

            migrationBuilder.DropColumn(
                name: "Guests",
                table: "TourBookings");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "TourBookings");
        }
    }
}
