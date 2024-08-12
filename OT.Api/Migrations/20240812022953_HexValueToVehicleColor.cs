using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OT.Api.Migrations
{
    /// <inheritdoc />
    public partial class HexValueToVehicleColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicleColors",
                table: "vehicleColors");

            migrationBuilder.RenameTable(
                name: "vehicleColors",
                newName: "VehicleColors");

            migrationBuilder.AddColumn<string>(
                name: "HexValue",
                table: "VehicleColors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleColors",
                table: "VehicleColors",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleColors",
                table: "VehicleColors");

            migrationBuilder.DropColumn(
                name: "HexValue",
                table: "VehicleColors");

            migrationBuilder.RenameTable(
                name: "VehicleColors",
                newName: "vehicleColors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicleColors",
                table: "vehicleColors",
                column: "Id");
        }
    }
}
