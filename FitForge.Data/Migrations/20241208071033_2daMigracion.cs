using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitForge.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2daMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Clases",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Clases");
        }
    }
}
