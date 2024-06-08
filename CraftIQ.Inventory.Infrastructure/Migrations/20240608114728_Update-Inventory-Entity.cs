using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftIQ.Inventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInventoryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Inventories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Inventories");
        }
    }
}
