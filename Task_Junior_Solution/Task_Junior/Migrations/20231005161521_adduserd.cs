using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_Junior.Migrations
{
    /// <inheritdoc />
    public partial class adduserd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e708fb2-a991-439d-8fee-c418aeb36452");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f284e752-ec94-4f3e-814f-daf59a12d870");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46f1685f-a4ae-4452-b311-185c5e07d321", null, "Admin", "ADMIN" },
                    { "9b349d27-44eb-4dfb-a7c9-1a3419783ffd", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserID",
                table: "Products",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UserID",
                table: "Products",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserID",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46f1685f-a4ae-4452-b311-185c5e07d321");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b349d27-44eb-4dfb-a7c9-1a3419783ffd");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9e708fb2-a991-439d-8fee-c418aeb36452", null, "Admin", "ADMIN" },
                    { "f284e752-ec94-4f3e-814f-daf59a12d870", null, "User", "USER" }
                });
        }
    }
}
