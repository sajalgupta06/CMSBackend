using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSBackend.Migrations
{
    /// <inheritdoc />
    public partial class removedadmindata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "Name", "Password", "Role", "Status" },
                values: new object[] { 1, "9977859801", "admin@gmail.com", "Admin", "admin123456", "ADMIN", 1 });
        }
    }
}
