using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeChinhPhucToan_BE.Migrations
{
    /// <inheritdoc />
    public partial class Test_AddAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "code",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                table: "Tests");
        }
    }
}
