using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_Junior.Migrations
{
    /// <inheritdoc />
    public partial class AddImage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dc794b2-be51-4d40-a060-0829f8b9e1af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d51b4d65-4533-48a9-8d74-0939b151b6f1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "647164f8-eb47-42e4-8ea9-06d20306c26f", null, "User", "USER" },
                    { "fde814c3-5aec-4405-be2f-8cc3805234c3", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "647164f8-eb47-42e4-8ea9-06d20306c26f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fde814c3-5aec-4405-be2f-8cc3805234c3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3dc794b2-be51-4d40-a060-0829f8b9e1af", null, "Admin", "ADMIN" },
                    { "d51b4d65-4533-48a9-8d74-0939b151b6f1", null, "User", "USER" }
                });
        }
    }
}
