using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_Junior.Migrations
{
    /// <inheritdoc />
    public partial class seed23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10a14498-d82b-493b-9591-b32c3402aba8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ad2e410-2739-482f-ac15-60cc9177bd89");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10a14498-d82b-493b-9591-b32c3402aba8", null, "User", "USER" },
                    { "9ad2e410-2739-482f-ac15-60cc9177bd89", null, "Admin", "ADMIN" }
                });
        }
    }
}
