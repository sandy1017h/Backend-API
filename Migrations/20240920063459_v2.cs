using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "OriginalPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "products",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "products",
                type: "decimal(5,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "products");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "OriginalPrice",
                table: "products",
                newName: "Price");
        }
    }
}
