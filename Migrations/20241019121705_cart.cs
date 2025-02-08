using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wishlistItems_products_ProductId",
                table: "wishlistItems");

            migrationBuilder.DropForeignKey(
                name: "FK_wishlistItems_wishlists_WishlistId",
                table: "wishlistItems");

            migrationBuilder.DropForeignKey(
                name: "FK_wishlists_users_UserId",
                table: "wishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_wishlists",
                table: "wishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_wishlistItems",
                table: "wishlistItems");

            migrationBuilder.RenameTable(
                name: "wishlists",
                newName: "Wishlists");

            migrationBuilder.RenameTable(
                name: "wishlistItems",
                newName: "WishlistItems");

            migrationBuilder.RenameIndex(
                name: "IX_wishlists_UserId",
                table: "Wishlists",
                newName: "IX_Wishlists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_wishlistItems_WishlistId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_WishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_wishlistItems_ProductId",
                table: "WishlistItems",
                newName: "IX_WishlistItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishlistItems",
                table: "WishlistItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Shopcarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopcarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shopcarts_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopcartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopcartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopcartItems_Shopcarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "Shopcarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopcartItems_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopcartItems_ProductId",
                table: "ShopcartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopcartItems_ShoppingCartId",
                table: "ShopcartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Shopcarts_UserId",
                table: "Shopcarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_Wishlists_WishlistId",
                table: "WishlistItems",
                column: "WishlistId",
                principalTable: "Wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistItems_products_ProductId",
                table: "WishlistItems",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_users_UserId",
                table: "Wishlists",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_Wishlists_WishlistId",
                table: "WishlistItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistItems_products_ProductId",
                table: "WishlistItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_users_UserId",
                table: "Wishlists");

            migrationBuilder.DropTable(
                name: "ShopcartItems");

            migrationBuilder.DropTable(
                name: "Shopcarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wishlists",
                table: "Wishlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishlistItems",
                table: "WishlistItems");

            migrationBuilder.RenameTable(
                name: "Wishlists",
                newName: "wishlists");

            migrationBuilder.RenameTable(
                name: "WishlistItems",
                newName: "wishlistItems");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlists_UserId",
                table: "wishlists",
                newName: "IX_wishlists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_WishlistId",
                table: "wishlistItems",
                newName: "IX_wishlistItems_WishlistId");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistItems_ProductId",
                table: "wishlistItems",
                newName: "IX_wishlistItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_wishlists",
                table: "wishlists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_wishlistItems",
                table: "wishlistItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_wishlistItems_products_ProductId",
                table: "wishlistItems",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wishlistItems_wishlists_WishlistId",
                table: "wishlistItems",
                column: "WishlistId",
                principalTable: "wishlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wishlists_users_UserId",
                table: "wishlists",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
