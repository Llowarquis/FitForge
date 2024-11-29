using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitForge.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoModelosNormalizados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    ClaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cupos = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.ClaseId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Pin = table.Column<int>(type: "int", nullable: false),
                    UrlFotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Dias",
                columns: table => new
                {
                    DiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dias", x => x.DiaId);
                });

            migrationBuilder.CreateTable(
                name: "EstadosMembresia",
                columns: table => new
                {
                    EstadoMembresiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosMembresia", x => x.EstadoMembresiaId);
                });

            migrationBuilder.CreateTable(
                name: "FormasPago",
                columns: table => new
                {
                    FormasPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPago", x => x.FormasPagoId);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    HorarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.HorarioId);
                });

            migrationBuilder.CreateTable(
                name: "Entrenadores",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<int>(type: "int", nullable: false),
                    ClaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrenadores", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_Entrenadores_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "ClaseId");
                });

            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    DomicilioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumCasa = table.Column<int>(type: "int", nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.DomicilioId);
                    table.ForeignKey(
                        name: "FK_Domicilios_Clientes_ClienteId",
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
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    NumeroTarjeta = table.Column<int>(type: "int", nullable: false),
                    Cvv = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.TarjetaId);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    TelefonoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.TelefonoId);
                    table.ForeignKey(
                        name: "FK_Telefonos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membresias",
                columns: table => new
                {
                    MembresiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoMembresiaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membresias", x => x.MembresiaId);
                    table.ForeignKey(
                        name: "FK_Membresias_EstadosMembresia_EstadoMembresiaId",
                        column: x => x.EstadoMembresiaId,
                        principalTable: "EstadosMembresia",
                        principalColumn: "EstadoMembresiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiasHorarios",
                columns: table => new
                {
                    DiaHorarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaId = table.Column<int>(type: "int", nullable: false),
                    HorarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasHorarios", x => x.DiaHorarioId);
                    table.ForeignKey(
                        name: "FK_DiasHorarios_Dias_DiaId",
                        column: x => x.DiaId,
                        principalTable: "Dias",
                        principalColumn: "DiaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiasHorarios_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarjetaId = table.Column<int>(type: "int", nullable: false),
                    FormasPagoId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pagos_FormasPago_FormasPagoId",
                        column: x => x.FormasPagoId,
                        principalTable: "FormasPago",
                        principalColumn: "FormasPagoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_Tarjetas_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjetas",
                        principalColumn: "TarjetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorariosDeClases",
                columns: table => new
                {
                    HorarioDeClaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaseId = table.Column<int>(type: "int", nullable: false),
                    DiaHorarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorariosDeClases", x => x.HorarioDeClaseId);
                    table.ForeignKey(
                        name: "FK_HorariosDeClases_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "ClaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorariosDeClases_DiasHorarios_DiaHorarioId",
                        column: x => x.DiaHorarioId,
                        principalTable: "DiasHorarios",
                        principalColumn: "DiaHorarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    InscripcionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    MembresiaId = table.Column<int>(type: "int", nullable: false),
                    HorarioDeClaseId = table.Column<int>(type: "int", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    EntrenadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.InscripcionId);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Entrenadores_EntrenadorId",
                        column: x => x.EntrenadorId,
                        principalTable: "Entrenadores",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_HorariosDeClases_HorarioDeClaseId",
                        column: x => x.HorarioDeClaseId,
                        principalTable: "HorariosDeClases",
                        principalColumn: "HorarioDeClaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Membresias_MembresiaId",
                        column: x => x.MembresiaId,
                        principalTable: "Membresias",
                        principalColumn: "MembresiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiasHorarios_DiaId",
                table: "DiasHorarios",
                column: "DiaId");

            migrationBuilder.CreateIndex(
                name: "IX_DiasHorarios_HorarioId",
                table: "DiasHorarios",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilios_ClienteId",
                table: "Domicilios",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrenadores_ClaseId",
                table: "Entrenadores",
                column: "ClaseId",
                unique: true,
                filter: "[ClaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HorariosDeClases_ClaseId",
                table: "HorariosDeClases",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_HorariosDeClases_DiaHorarioId",
                table: "HorariosDeClases",
                column: "DiaHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ClienteId",
                table: "Inscripciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EntrenadorId",
                table: "Inscripciones",
                column: "EntrenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_HorarioDeClaseId",
                table: "Inscripciones",
                column: "HorarioDeClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_MembresiaId",
                table: "Inscripciones",
                column: "MembresiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Membresias_EstadoMembresiaId",
                table: "Membresias",
                column: "EstadoMembresiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_FormasPagoId",
                table: "Pagos",
                column: "FormasPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TarjetaId",
                table: "Pagos",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_ClienteId",
                table: "Tarjetas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_ClienteId",
                table: "Telefonos",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Domicilios");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Telefonos");

            migrationBuilder.DropTable(
                name: "Entrenadores");

            migrationBuilder.DropTable(
                name: "HorariosDeClases");

            migrationBuilder.DropTable(
                name: "Membresias");

            migrationBuilder.DropTable(
                name: "FormasPago");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "DiasHorarios");

            migrationBuilder.DropTable(
                name: "EstadosMembresia");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Dias");

            migrationBuilder.DropTable(
                name: "Horarios");
        }
    }
}
