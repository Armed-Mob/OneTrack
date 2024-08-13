using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OT.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreateShopSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopOwner",
                table: "Shops");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopOwner",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
