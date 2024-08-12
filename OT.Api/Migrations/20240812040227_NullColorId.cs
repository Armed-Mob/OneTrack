using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OT.Api.Migrations
{
    /// <inheritdoc />
    public partial class NullColorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "VehicleDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "VehicleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
