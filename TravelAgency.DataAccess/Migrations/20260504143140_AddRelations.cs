using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Description_DescriptionAdvanced_DescriptionAdvancedId",
                table: "Description");

            migrationBuilder.DropForeignKey(
                name: "FK_TourImgs_Tours_TourDataId",
                table: "TourImgs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Description_DescriptionId",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Tours_DescriptionId",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_TourImgs_TourDataId",
                table: "TourImgs");

            migrationBuilder.DropIndex(
                name: "IX_Description_DescriptionAdvancedId",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "TourDataId",
                table: "TourImgs");

            migrationBuilder.RenameColumn(
                name: "DescriptionAdvancedId",
                table: "Description",
                newName: "TourId");

            migrationBuilder.AddColumn<int>(
                name: "TourDescriptionDataId",
                table: "DescriptionAdvanced",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TourImgs_TourId",
                table: "TourImgs",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionAdvanced_TourDescriptionDataId",
                table: "DescriptionAdvanced",
                column: "TourDescriptionDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Description_TourId",
                table: "Description",
                column: "TourId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Description_Tours_TourId",
                table: "Description",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionAdvanced_Description_TourDescriptionDataId",
                table: "DescriptionAdvanced",
                column: "TourDescriptionDataId",
                principalTable: "Description",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourImgs_Tours_TourId",
                table: "TourImgs",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Description_Tours_TourId",
                table: "Description");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionAdvanced_Description_TourDescriptionDataId",
                table: "DescriptionAdvanced");

            migrationBuilder.DropForeignKey(
                name: "FK_TourImgs_Tours_TourId",
                table: "TourImgs");

            migrationBuilder.DropIndex(
                name: "IX_TourImgs_TourId",
                table: "TourImgs");

            migrationBuilder.DropIndex(
                name: "IX_DescriptionAdvanced_TourDescriptionDataId",
                table: "DescriptionAdvanced");

            migrationBuilder.DropIndex(
                name: "IX_Description_TourId",
                table: "Description");

            migrationBuilder.DropColumn(
                name: "TourDescriptionDataId",
                table: "DescriptionAdvanced");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "Description",
                newName: "DescriptionAdvancedId");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Tours",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TourDataId",
                table: "TourImgs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tours_DescriptionId",
                table: "Tours",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TourImgs_TourDataId",
                table: "TourImgs",
                column: "TourDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Description_DescriptionAdvancedId",
                table: "Description",
                column: "DescriptionAdvancedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Description_DescriptionAdvanced_DescriptionAdvancedId",
                table: "Description",
                column: "DescriptionAdvancedId",
                principalTable: "DescriptionAdvanced",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourImgs_Tours_TourDataId",
                table: "TourImgs",
                column: "TourDataId",
                principalTable: "Tours",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Description_DescriptionId",
                table: "Tours",
                column: "DescriptionId",
                principalTable: "Description",
                principalColumn: "Id");
        }
    }
}
