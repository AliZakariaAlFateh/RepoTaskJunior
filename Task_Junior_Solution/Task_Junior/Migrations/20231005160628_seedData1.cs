using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_Junior.Migrations
{
    /// <inheritdoc />
    public partial class seedData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bf13614-c219-4266-99f5-a96ae1690c82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5593f1b8-1184-4e0b-802e-5f3ccb52ede6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9e708fb2-a991-439d-8fee-c418aeb36452", null, "Admin", "ADMIN" },
                    { "f284e752-ec94-4f3e-814f-daf59a12d870", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e708fb2-a991-439d-8fee-c418aeb36452");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f284e752-ec94-4f3e-814f-daf59a12d870");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bf13614-c219-4266-99f5-a96ae1690c82", null, "User", "USER" },
                    { "5593f1b8-1184-4e0b-802e-5f3ccb52ede6", null, "Admin", "ADMIN" }
                });
        }
    }
}
