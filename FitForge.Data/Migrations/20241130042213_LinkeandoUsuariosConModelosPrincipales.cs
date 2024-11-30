using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitForge.Data.Migrations
{
    /// <inheritdoc />
    public partial class LinkeandoUsuariosConModelosPrincipales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Entrenadores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entrenadores_ApplicationUserId",
                table: "Entrenadores",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ApplicationUserId",
                table: "Clientes",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_AspNetUsers_ApplicationUserId",
                table: "Clientes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrenadores_AspNetUsers_ApplicationUserId",
                table: "Entrenadores",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_AspNetUsers_ApplicationUserId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrenadores_AspNetUsers_ApplicationUserId",
                table: "Entrenadores");

            migrationBuilder.DropIndex(
                name: "IX_Entrenadores_ApplicationUserId",
                table: "Entrenadores");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ApplicationUserId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Entrenadores");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Clientes");
        }
    }
}
