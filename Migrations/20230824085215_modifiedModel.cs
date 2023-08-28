using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSBackend.Migrations
{
    /// <inheritdoc />
    public partial class modifiedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductIds",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductIds",
                table: "Orders",
                newName: "OrderedItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ProductIds",
                table: "Orders",
                newName: "IX_Orders_OrderedItemsId");

            migrationBuilder.CreateTable(
                name: "OrderedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    ProductsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedItems_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_ProductsId",
                table: "OrderedItems",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderedItems_OrderedItemsId",
                table: "Orders",
                column: "OrderedItemsId",
                principalTable: "OrderedItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderedItems_OrderedItemsId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderedItems");

            migrationBuilder.RenameColumn(
                name: "OrderedItemsId",
                table: "Orders",
                newName: "ProductIds");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderedItemsId",
                table: "Orders",
                newName: "IX_Orders_ProductIds");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductIds",
                table: "Orders",
                column: "ProductIds",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
