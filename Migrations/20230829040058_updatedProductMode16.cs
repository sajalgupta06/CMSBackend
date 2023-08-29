using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSBackend.Migrations
{
    /// <inheritdoc />
    public partial class updatedProductMode16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderedItems_OrderedItemId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderedItemId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderedItemId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderedItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_OrderId",
                table: "OrderedItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItems_Orders_OrderId",
                table: "OrderedItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItems_Orders_OrderId",
                table: "OrderedItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderedItems_OrderId",
                table: "OrderedItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderedItems");

            migrationBuilder.AddColumn<int>(
                name: "OrderedItemId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderedItemId",
                table: "Orders",
                column: "OrderedItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderedItems_OrderedItemId",
                table: "Orders",
                column: "OrderedItemId",
                principalTable: "OrderedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
