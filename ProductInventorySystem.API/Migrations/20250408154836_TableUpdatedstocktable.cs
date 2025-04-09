using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductInventorySystem.API.Migrations
{
    /// <inheritdoc />
    public partial class TableUpdatedstocktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAddition",
                table: "Stocks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAddition",
                table: "Stocks");
        }
    }
}
