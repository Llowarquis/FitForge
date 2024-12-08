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

            modelBuilder.HasSequence<int>("Pin", "dbo")
                .StartsAt(1000L);

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

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("ClaseId");

                    b.ToTable("Clases");
                });

            modelBuilder.Entity("FitForge.Data.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR Pin");

                    b.Property<string>("UrlFotoPerfil")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.HasIndex("ApplicationUserId");

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

                    b.Property<int?>("DiasHorariosDiaHorarioId")
                        .HasColumnType("int");

                    b.HasKey("DiaId");

                    b.HasIndex("DiasHorariosDiaHorarioId");

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
                    b.Property<int>("EntrenadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntrenadorId"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly>("FechaIngreso")
                        .HasColumnType("date");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlFotoPerfil")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntrenadorId");

                    b.HasIndex("ApplicationUserId");

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

                    b.Property<int?>("DiasHorariosDiaHorarioId")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("HoraFin")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("HoraInicio")
                        .HasColumnType("time");

                    b.HasKey("HorarioId");

                    b.HasIndex("DiasHorariosDiaHorarioId");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("FitForge.Data.Models.Itinerarios", b =>
                {
                    b.Property<int>("ItinerarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItinerarioId"));

                    b.Property<int>("ClaseId")
                        .HasColumnType("int");

                    b.Property<int>("DiaHorarioId")
                        .HasColumnType("int");

                    b.Property<int>("EntrenadorId")
                        .HasColumnType("int");

                    b.HasKey("ItinerarioId");

                    b.HasIndex("ClaseId");

                    b.HasIndex("DiaHorarioId");

                    b.HasIndex("EntrenadorId");

                    b.ToTable("Itinerarios");
                });

            modelBuilder.Entity("FitForge.Data.Models.Membresias", b =>
                {
                    b.Property<int>("MembresiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MembresiaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoMembresiaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("MembresiaId");

                    b.HasIndex("EstadoMembresiaId");

                    b.ToTable("Membresias");
                });

            modelBuilder.Entity("FitForge.Data.Models.Pagos", b =>
                {
                    b.Property<int>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagoId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormasPagoId")
                        .HasColumnType("int");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<int>("TarjetaId")
                        .HasColumnType("int");

                    b.HasKey("PagoId");

                    b.HasIndex("ClienteId");

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

            modelBuilder.Entity("FitForge.Data.Modelsp.Inscripciones", b =>
                {
                    b.Property<int>("InscripcionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InscripcionId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("EntrenadorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ItinerarioId")
                        .HasColumnType("int");

                    b.Property<int>("MembresiaId")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("InscripcionId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EntrenadorId");

                    b.HasIndex("ItinerarioId");

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

            modelBuilder.Entity("FitForge.Data.Models.Clientes", b =>
                {
                    b.HasOne("FitForge.Data.DAL.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("FitForge.Data.Models.Dias", b =>
                {
                    b.HasOne("FitForge.Data.Models.DiasHorarios", null)
                        .WithMany("Dias")
                        .HasForeignKey("DiasHorariosDiaHorarioId");
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
                    b.HasOne("FitForge.Data.DAL.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("FitForge.Data.Models.Horarios", b =>
                {
                    b.HasOne("FitForge.Data.Models.DiasHorarios", null)
                        .WithMany("Horario")
                        .HasForeignKey("DiasHorariosDiaHorarioId");
                });

            modelBuilder.Entity("FitForge.Data.Models.Itinerarios", b =>
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

                    b.HasOne("FitForge.Data.Models.Entrenadores", "Entrenador")
                        .WithMany()
                        .HasForeignKey("EntrenadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clase");

                    b.Navigation("DiaHorario");

                    b.Navigation("Entrenador");
                });

            modelBuilder.Entity("FitForge.Data.Models.Membresias", b =>
                {
                    b.HasOne("FitForge.Data.Models.EstadosMembresia", "EstadoMembresia")
                        .WithMany()
                        .HasForeignKey("EstadoMembresiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoMembresia");
                });

            modelBuilder.Entity("FitForge.Data.Models.Pagos", b =>
                {
                    b.HasOne("FitForge.Data.Models.Clientes", "Cliente")
                        .WithMany("PagosEfectivo")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitForge.Data.Models.FormasPago", "FormaPago")
                        .WithMany()
                        .HasForeignKey("FormasPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitForge.Data.Models.Tarjetas", "Tarjeta")
                        .WithMany("Pagos")
                        .HasForeignKey("TarjetaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

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

            modelBuilder.Entity("FitForge.Data.Modelsp.Inscripciones", b =>
                {
                    b.HasOne("FitForge.Data.Models.Clientes", "Cliente")
                        .WithMany("Inscripciones")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitForge.Data.Models.Entrenadores", "Entrenador")
                        .WithMany()
                        .HasForeignKey("EntrenadorId");

                    b.HasOne("FitForge.Data.Models.Itinerarios", "Itinerario")
                        .WithMany()
                        .HasForeignKey("ItinerarioId");

                    b.HasOne("FitForge.Data.Models.Membresias", "Membresia")
                        .WithMany()
                        .HasForeignKey("MembresiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Entrenador");

                    b.Navigation("Itinerario");

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

            modelBuilder.Entity("FitForge.Data.Models.Clientes", b =>
                {
                    b.Navigation("Inscripciones");

                    b.Navigation("PagosEfectivo");

                    b.Navigation("Tarjetas");
                });

            modelBuilder.Entity("FitForge.Data.Models.DiasHorarios", b =>
                {
                    b.Navigation("Dias");

                    b.Navigation("Horario");
                });

            modelBuilder.Entity("FitForge.Data.Models.Tarjetas", b =>
                {
                    b.Navigation("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
