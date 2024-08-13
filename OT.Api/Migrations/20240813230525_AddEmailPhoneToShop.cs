using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OT.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailPhoneToShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopEmail",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopOwner",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopPhone",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopEmail",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "ShopOwner",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "ShopPhone",
                table: "Shops");
        }
    }
}
