using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OT.Api.Migrations
{
    /// <inheritdoc />
    public partial class change_stringColorto_intColorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "VehicleDetails");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "VehicleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "VehicleDetails");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "VehicleDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
