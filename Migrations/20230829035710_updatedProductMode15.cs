using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSBackend.Migrations
{
    /// <inheritdoc />
    public partial class updatedProductMode15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderedItems_OrderedItemsId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderedItemsId",
                table: "Orders",
                newName: "OrderedItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderedItemsId",
                table: "Orders",
                newName: "IX_Orders_OrderedItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderedItems_OrderedItemId",
                table: "Orders",
                column: "OrderedItemId",
                principalTable: "OrderedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderedItems_OrderedItemId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderedItemId",
                table: "Orders",
                newName: "OrderedItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderedItemId",
                table: "Orders",
                newName: "IX_Orders_OrderedItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderedItems_OrderedItemsId",
                table: "Orders",
                column: "OrderedItemsId",
                principalTable: "OrderedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
