using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSBackend.Migrations
{
    /// <inheritdoc />
    public partial class updatedProductMode8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderedItemsId",
                table: "Orders",
                column: "OrderedItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_ProductsId",
                table: "OrderedItems",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItems_Products_ProductsId",
                table: "OrderedItems",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderedItems_OrderedItemsId",
                table: "Orders",
                column: "OrderedItemsId",
                principalTable: "OrderedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItems_Products_ProductsId",
                table: "OrderedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderedItems_OrderedItemsId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderedItemsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderedItems_ProductsId",
                table: "OrderedItems");
        }
    }
}
