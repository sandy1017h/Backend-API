using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class addednewcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brands_images_ImageId",
                table: "brands");

            migrationBuilder.DropForeignKey(
                name: "FK_categories_images_ImageId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_products_images_ThumbnailId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopcartItems_Shopcarts_ShoppingCartId",
                table: "ShopcartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Shopcarts_users_UserId",
                table: "Shopcarts");

            migrationBuilder.DropIndex(
                name: "IX_Shopcarts_UserId",
                table: "Shopcarts");

            migrationBuilder.DropIndex(
                name: "IX_ShopcartItems_ShoppingCartId",
                table: "ShopcartItems");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_brands_ImageId",
                table: "brands");

            migrationBuilder.DropColumn(
                name: "Processor",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Storage",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "images");

            migrationBuilder.DropColumn(
                name: "ImageNameExt",
                table: "images");

            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "ShopcartItems",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrderItems",
                newName: "Subtotal");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "images",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Shopcarts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Shopcarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Shopcarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Shopcarts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Shopcarts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "ShopcartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ShopcartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ShopcartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ShopcartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ShopcartItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RazorpayOrderId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "brands",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Electronic gadgets and devices");

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Clothing and fashion accessories");

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Appliances for home use", "Home Appliances" });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Books from various genres", "Books" });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Daily essentials and groceries", "Groceries" });

            migrationBuilder.InsertData(
                table: "images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Url" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://images.unsplash.com/photo-1662947995643-0007c2b5ebb6?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fHNhbXN1bmclMjBsb2dvfGVufDB8fDB8fHww" },
                    { 2, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://www.freeiconspng.com/thumbs/apple-logo-icon/blue-apple-logo-icon-0.png" },
                    { 3, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://cdn.freebiesupply.com/logos/large/2x/sony-logo-png-transparent.png" },
                    { 4, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://e7.pngegg.com/pngimages/255/673/png-clipart-dell-logo-illustration-dell-sonicwall-logo-dell-logo-blue-text-thumbnail.png" },
                    { 5, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://i.pinimg.com/736x/a7/15/be/a715beeaceeba3b6fdbcb29717032cc8.jpg" },
                    { 6, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://upload.wikimedia.org/wikipedia/commons/2/24/Adidas_logo.png" },
                    { 7, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://w7.pngwing.com/pngs/670/927/png-transparent-puma-logo-puma-logo-adidas-swoosh-brand-adidas-text-carnivoran-sneakers-thumbnail.png" },
                    { 8, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://w7.pngwing.com/pngs/581/271/png-transparent-levi%C2%B4s-store-frolunda-torg-levi-strauss-co-brand-sweater-levi-text-label-rectangle-thumbnail.png" },
                    { 9, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://w7.pngwing.com/pngs/675/344/png-transparent-lg-logo-lg-g5-lg-electronics-lg-corp-lg-logo-text-trademark-logo.png" },
                    { 10, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://example.com/brands/whirlpool.png" },
                    { 11, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://upload.wikimedia.org/wikipedia/commons/1/10/Whirlpool_Corporation_Logo.png" },
                    { 12, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://w7.pngwing.com/pngs/370/224/png-transparent-bosch-logo-thumbnail.png" },
                    { 13, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://preview.redd.it/q1tkmm77nza31.png?auto=webp&s=fd0fe1175193ec462c1625eb28b02cea8e5eaae4" },
                    { 14, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://www.liblogo.com/img-logo/ha1286h474-harpercollins-logo-harpercollins-javelin.png" },
                    { 15, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://logowik.com/content/uploads/images/simon-data6544.logowik.com.webp" },
                    { 16, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://upload.wikimedia.org/wikipedia/commons/5/5e/Hachette_India_logo.png" },
                    { 17, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://w7.pngwing.com/pngs/342/57/png-transparent-nestle-logo-nestle-logo-nestle-ghana-ltd-nestle-blue-angle-building-thumbnail.png" },
                    { 18, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://m.economictimes.com/thumb/msid-76233259,width-1200,height-900,resizemode-4,imgsize-672052/amul.jpg" },
                    { 19, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://upload.wikimedia.org/wikipedia/en/thumb/5/50/Britannia_Industries_logo_with_motto.svg/2560px-Britannia_Industries_logo_with_motto.svg.png" },
                    { 20, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, "https://www.yogaiya.in/wp-content/uploads/2018/08/Patanjali-Yogpeeth.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopcartItems_CartId",
                table: "ShopcartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_brands_ImageId",
                table: "brands",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_brands_images_ImageId",
                table: "brands",
                column: "ImageId",
                principalTable: "images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_categories_images_ImageId",
                table: "categories",
                column: "ImageId",
                principalTable: "images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_images_ThumbnailId",
                table: "products",
                column: "ThumbnailId",
                principalTable: "images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopcartItems_Shopcarts_CartId",
                table: "ShopcartItems",
                column: "CartId",
                principalTable: "Shopcarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brands_images_ImageId",
                table: "brands");

            migrationBuilder.DropForeignKey(
                name: "FK_categories_images_ImageId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_images_ThumbnailId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopcartItems_Shopcarts_CartId",
                table: "ShopcartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShopcartItems_CartId",
                table: "ShopcartItems");

            migrationBuilder.DropIndex(
                name: "IX_brands_ImageId",
                table: "brands");

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "images",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Shopcarts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Shopcarts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Shopcarts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Shopcarts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Shopcarts");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "ShopcartItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ShopcartItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ShopcartItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ShopcartItems");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ShopcartItems");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RazorpayOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "images");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "images");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "images");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "images");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "images");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "categories");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ShopcartItems",
                newName: "ShoppingCartId");

            migrationBuilder.RenameColumn(
                name: "Subtotal",
                table: "OrderItems",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "images",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Processor",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ram",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Storage",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedBy",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageNameExt",
                table: "images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "brands",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Home & Kitchen");

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Beauty & Personal Care");

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Sports & Outdoors");

            migrationBuilder.CreateIndex(
                name: "IX_Shopcarts_UserId",
                table: "Shopcarts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopcartItems_ShoppingCartId",
                table: "ShopcartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_brands_ImageId",
                table: "brands",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_brands_images_ImageId",
                table: "brands",
                column: "ImageId",
                principalTable: "images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_categories_images_ImageId",
                table: "categories",
                column: "ImageId",
                principalTable: "images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_images_ThumbnailId",
                table: "products",
                column: "ThumbnailId",
                principalTable: "images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopcartItems_Shopcarts_ShoppingCartId",
                table: "ShopcartItems",
                column: "ShoppingCartId",
                principalTable: "Shopcarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shopcarts_users_UserId",
                table: "Shopcarts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
