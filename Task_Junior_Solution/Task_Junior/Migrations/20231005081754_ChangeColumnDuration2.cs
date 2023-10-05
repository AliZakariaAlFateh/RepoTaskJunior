using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Junior.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnDuration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Products",
                newName: "Duration_EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration_EndDate",
                table: "Products",
                newName: "Duration");
        }
    }
}
