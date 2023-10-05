using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_Junior.Migrations
{
    /// <inheritdoc />
    public partial class seedtest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bd9dbab2-7b8a-4b81-9d7b-a47faa6f764e", null, "Admin", "ADMIN" },
                    { "ee20b52b-23aa-409d-965a-934f7d62b4b4", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd9dbab2-7b8a-4b81-9d7b-a47faa6f764e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee20b52b-23aa-409d-965a-934f7d62b4b4");
        }
    }
}
