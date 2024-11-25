using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitForge.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cajas",
                columns: table => new
                {
                    CajaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BalanceEfectivo = table.Column<double>(type: "float", nullable: false),
                    BalanceBanco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cajas", x => x.CajaId);
                });

            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    DomicilioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumCalle = table.Column<int>(type: "int", nullable: false),
                    NumCasa = table.Column<int>(type: "int", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.DomicilioId);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pin = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sueldo = table.Column<double>(type: "float", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "Gerentes",
                columns: table => new
                {
                    GerenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerentes", x => x.GerenteId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<long>(type: "bigint", nullable: false),
                    Pin = table.Column<int>(type: "int", nullable: false),
                    FotoPerfilUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: true),
                    DomicilioId = table.Column<int>(type: "int", nullable: false),
                    PagoEfectivoId = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Membresia = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Domicilios_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "Domicilios",
                        principalColumn: "DomicilioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagosEfectivo",
                columns: table => new
                {
                    PagoEfectivoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CajasId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosEfectivo", x => x.PagoEfectivoId);
                    table.ForeignKey(
                        name: "FK_PagosEfectivo_Cajas_CajasId",
                        column: x => x.CajasId,
                        principalTable: "Cajas",
                        principalColumn: "CajaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagosEfectivo_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    TarjetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTarjeta = table.Column<int>(type: "int", nullable: false),
                    Cvv = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    ClientesClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.TarjetaId);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Clientes_ClientesClienteId",
                        column: x => x.ClientesClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId");
                });

            migrationBuilder.CreateTable(
                name: "PagosTarjeta",
                columns: table => new
                {
                    PagoTarjetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TarjetaId = table.Column<int>(type: "int", nullable: false),
                    CajaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosTarjeta", x => x.PagoTarjetaId);
                    table.ForeignKey(
                        name: "FK_PagosTarjeta_Cajas_CajaId",
                        column: x => x.CajaId,
                        principalTable: "Cajas",
                        principalColumn: "CajaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagosTarjeta_Tarjetas_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjetas",
                        principalColumn: "TarjetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DomicilioId",
                table: "Clientes",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosEfectivo_CajasId",
                table: "PagosEfectivo",
                column: "CajasId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosEfectivo_ClienteId",
                table: "PagosEfectivo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosTarjeta_CajaId",
                table: "PagosTarjeta",
                column: "CajaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosTarjeta_TarjetaId",
                table: "PagosTarjeta",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_ClientesClienteId",
                table: "Tarjetas",
                column: "ClientesClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Gerentes");

            migrationBuilder.DropTable(
                name: "PagosEfectivo");

            migrationBuilder.DropTable(
                name: "PagosTarjeta");

            migrationBuilder.DropTable(
                name: "Cajas");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Domicilios");
        }
    }
}
