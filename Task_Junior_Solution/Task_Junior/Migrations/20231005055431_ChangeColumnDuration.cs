using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Junior.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Products",
                newName: "Duration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Products",
                newName: "MyProperty");
        }
    }
}
