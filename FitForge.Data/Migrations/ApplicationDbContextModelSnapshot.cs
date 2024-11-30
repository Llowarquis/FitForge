﻿// <auto-generated />
using System;
using FitForge.Data.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitForge.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitForge.Data.DAL.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("FitForge.Data.Models.Clases", b =>
                {
                    b.Property<int>("ClaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClaseId"));

                    b.Property<int>("Cupos")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.HasKey("ClaseId");

                    b.ToTable("Clases");
                });

            modelBuilder.Entity("FitForge.Data.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<int>("Cedula")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.Property<string>("UrlFotoPerfil")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("FitForge.Data.Models.Dias", b =>
                {
                    b.Property<int>("DiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiaId"));

                    b.Property<string>("Dia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiaId");

                    b.ToTable("Dias");
                });

            modelBuilder.Entity("FitForge.Data.Models.DiasHorarios", b =>
                {
                    b.Property<int>("DiaHorarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiaHorarioId"));

                    b.Property<int>("DiaId")
                        .HasColumnType("int");

                    b.Property<int>("HorarioId")
                        .HasColumnType("int");

                    b.HasKey("DiaHorarioId");

                    b.HasIndex("DiaId");

                    b.HasIndex("HorarioId");

                    b.ToTable("DiasHorarios");
                });

            modelBuilder.Entity("FitForge.Data.Models.Domicilios", b =>
                {
                    b.Property<int>("DomicilioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DomicilioId"));

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("NumCasa")
                        .HasColumnType("int");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DomicilioId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Domicilios");
                });

            modelBuilder.Entity("FitForge.Data.Models.Entrenadores", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpleadoId"));

                    b.Property<int?>("ClaseId")
                        .HasColumnType("int");

                    b.Property<int>("Nombres")
                        .HasColumnType("int");

                    b.HasKey("EmpleadoId");

                    b.HasIndex("ClaseId")
                        .IsUnique()
                        .HasFilter("[ClaseId] IS NOT NULL");

                    b.ToTable("Entrenadores");
                });

            modelBuilder.Entity("FitForge.Data.Models.EstadosMembresia", b =>
                {
                    b.Property<int>("EstadoMembresiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoMembresiaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoMembresiaId");

                    b.ToTable("EstadosMembresia");

                    b.HasData(
                        new
                        {
                            EstadoMembresiaId = 1,
                            Descripcion = "Activo"
                        },
                        new
                        {
                            EstadoMembresiaId = 2,
                            Descripcion = "Suspendido"
                        },
                        new
                        {
                            EstadoMembresiaId = 3,
                            Descripcion = "Vencido"
                        });
                });

            modelBuilder.Entity("FitForge.Data.Models.FormasPago", b =>
                {
                    b.Property<int>("FormasPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormasPagoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormasPagoId");

                    b.ToTable("FormasPago");
                });

            modelBuilder.Entity("FitForge.Data.Models.Horarios", b =>
                {
                    b.Property<int>("HorarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HorarioId"));

                    b.Property<TimeOnly>("HoraFin")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("HoraInicio")
                        .HasColumnType("time");

                    b.HasKey("HorarioId");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("FitForge.Data.Models.HorariosDeClases", b =>
                {
                    b.Property<int>("HorarioDeClaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HorarioDeClaseId"));

                    b.Property<int>("ClaseId")
                        .HasColumnType("int");

                    b.Property<int>("DiaHorarioId")
                        .HasColumnType("int");

                    b.HasKey("HorarioDeClaseId");

                    b.HasIndex("ClaseId");

                    b.HasIndex("DiaHorarioId");

                    b.ToTable("HorariosDeClases");
                });

            modelBuilder.Entity("FitForge.Data.Models.Membresias", b =>
                {
                    b.Property<int>("MembresiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MembresiaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("EstadoMembresiaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaVencimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 12, 30, 9, 7, 35, 833, DateTimeKind.Local).AddTicks(8203));

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MembresiaId");

                    b.HasIndex("EstadoMembresiaId");

                    b.ToTable("Membresias");

                    b.HasData(
                        new
                        {
                            MembresiaId = 1,
                            Descripcion = "Membresía Estudiante",
                            EstadoMembresiaId = 1,
                            FechaVencimiento = new DateTime(2024, 12, 30, 9, 7, 35, 833, DateTimeKind.Local).AddTicks(9815),
                            Precio = 500m
                        },
                        new
                        {
                            MembresiaId = 2,
                            Descripcion = "Membresía Básica",
                            EstadoMembresiaId = 1,
                            FechaVencimiento = new DateTime(2024, 12, 30, 9, 7, 35, 833, DateTimeKind.Local).AddTicks(9819),
                            Precio = 800m
                        },
                        new
                        {
                            MembresiaId = 3,
                            Descripcion = "Membresía VIP",
                            EstadoMembresiaId = 1,
                            FechaVencimiento = new DateTime(2024, 12, 30, 9, 7, 35, 833, DateTimeKind.Local).AddTicks(9821),
                            Precio = 1500m
                        });
                });

            modelBuilder.Entity("FitForge.Data.Models.Pagos", b =>
                {
                    b.Property<int>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagoId"));

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormasPagoId")
                        .HasColumnType("int");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<int>("TarjetaId")
                        .HasColumnType("int");

                    b.HasKey("PagoId");

                    b.HasIndex("FormasPagoId");

                    b.HasIndex("TarjetaId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("FitForge.Data.Models.Tarjetas", b =>
                {
                    b.Property<int>("TarjetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TarjetaId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Cvv")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaVencimiento")
                        .HasColumnType("date");

                    b.Property<int>("NumeroTarjeta")
                        .HasColumnType("int");

                    b.HasKey("TarjetaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Tarjetas");
                });

            modelBuilder.Entity("FitForge.Data.Models.Telefonos", b =>
                {
                    b.Property<int>("TelefonoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TelefonoId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("TelefonoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Telefonos");
                });

            modelBuilder.Entity("FitForge.Data.Modelsp.Inscripciones", b =>
                {
                    b.Property<int>("InscripcionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InscripcionId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("EntrenadorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<int>("HorarioDeClaseId")
                        .HasColumnType("int");

                    b.Property<int>("MembresiaId")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("InscripcionId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EntrenadorId");

                    b.HasIndex("HorarioDeClaseId");

                    b.HasIndex("MembresiaId");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FitForge.Data.Models.DiasHorarios", b =>
                {
                    b.HasOne("FitForge.Data.Models.Dias", "Dia")
                        .WithMany()
                        .HasForeignKey("DiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitForge.Data.Models.Horarios", "Horario")
                        .WithMany()
                        .HasForeignKey("HorarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dia");

                    b.Navigation("Horario");
                });

            modelBuilder.Entity("FitForge.Data.Models.Domicilios", b =>
                {
                    b.HasOne("FitForge.Data.Models.Clientes", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("FitForge.Data.Models.Entrenadores", b =>
                {
                    b.HasOne("FitForge.Data.Models.Clases", "Clase")
                        .WithOne("Entrenador")
                        .HasForeignKey("FitForge.Data.Models.Entrenadores", "ClaseId");

                    b.Navigation("Clase");
                });

            modelBuilder.Entity("FitForge.Data.Models.HorariosDeClases", b =>
                {
                    b.HasOne("FitForge.Data.Models.Clases", "Clase")
                        .WithMany()
                        .HasForeignKey("ClaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitForge.Data.Models.DiasHorarios", "DiaHorario")
                        .WithMany()
                        .HasForeignKey("DiaHorarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clase");

                    b.Navigation("DiaHorario");
                });

            modelBuilder.Entity("FitForge.Data.Models.Membresias", b =>
                {
                    b.HasOne("FitForge.Data.Models.EstadosMembresia", "EstadoMembresia")
                        .WithMany()
                        .HasForeignKey("EstadoMembresiaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EstadoMembresia");
                });

            modelBuilder.Entity("FitForge.Data.Models.Pagos", b =>
                {
                    b.HasOne("FitForge.Data.Models.FormasPago", "FormaPago")
                        .WithMany()
                        .HasForeignKey("FormasPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitForge.Data.Models.Tarjetas", "Tarjeta")
                        .WithMany("Pagos")
                        .HasForeignKey("TarjetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormaPago");

                    b.Navigation("Tarjeta");
                });

            modelBuilder.Entity("FitForge.Data.Models.Tarjetas", b =>
                {
                    b.HasOne("FitForge.Data.Models.Clientes", "Cliente")
                        .WithMany("Tarjetas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("FitForge.Data.Models.Telefonos", b =>
                {
                    b.HasOne("FitForge.Data.Models.Clientes", "Cliente")
                        .WithMany("Telefonos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("FitForge.Data.Modelsp.Inscripciones", b =>
                {
                    b.HasOne("FitForge.Data.Models.Clientes", "Cliente")
                        .WithMany("Inscripciones")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitForge.Data.Models.Entrenadores", "Entrenador")
                        .WithMany()
                        .HasForeignKey("EntrenadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitForge.Data.Models.HorariosDeClases", "HorarioDeClase")
                        .WithMany()
                        .HasForeignKey("HorarioDeClaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitForge.Data.Models.Membresias", "Membresia")
                        .WithMany()
                        .HasForeignKey("MembresiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Entrenador");

                    b.Navigation("HorarioDeClase");

                    b.Navigation("Membresia");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FitForge.Data.DAL.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FitForge.Data.DAL.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitForge.Data.DAL.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FitForge.Data.DAL.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitForge.Data.Models.Clases", b =>
                {
                    b.Navigation("Entrenador")
                        .IsRequired();
                });

            modelBuilder.Entity("FitForge.Data.Models.Clientes", b =>
                {
                    b.Navigation("Inscripciones");

                    b.Navigation("Tarjetas");

                    b.Navigation("Telefonos");
                });

            modelBuilder.Entity("FitForge.Data.Models.Tarjetas", b =>
                {
                    b.Navigation("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
