using FitForge.Data.Models;
using FitForge.Data.Modelsp;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitForge.Data.DAL;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Clases> Clases { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Dias> Dias { get; set; }
    public DbSet<DiasHorarios> DiasHorarios { get; set; }
    public DbSet<Domicilios> Domicilios { get; set; }
    public DbSet<Entrenadores> Entrenadores { get; set; }
    public DbSet<EstadosMembresia> EstadosMembresia { get; set; }
    public DbSet<FormasPago> FormasPago { get; set; }
    public DbSet<Horarios> Horarios { get; set; }
    public DbSet<Itinerarios> Itinerarios { get; set; }
    public DbSet<Inscripciones> Inscripciones { get; set; }
    public DbSet<InscripcionesDetalle> InscripcionesDetalle { get; set; }
    public DbSet<Membresias> Membresias { get; set; }
    public DbSet<Pagos> Pagos { get; set; }
    public DbSet<Tarjetas> Tarjetas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de Clientes: Pin inicial
        modelBuilder.Entity<Clientes>()
            .Property(u => u.Pin)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEXT VALUE FOR Pin");

        modelBuilder.HasSequence<int>("Pin", schema: "dbo")
            .StartsAt(1000)
            .IncrementsBy(1);

        // Configuración de Pagos
        modelBuilder.Entity<Pagos>()
            .HasOne(p => p.Tarjeta)
            .WithMany(t => t.Pagos)
            .HasForeignKey(p => p.TarjetaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuración de Membresías
        modelBuilder.Entity<Membresias>()
            .HasKey(m => m.MembresiaId);

        modelBuilder.Entity<Membresias>()
            .Property(m => m.Descripcion)
            .IsRequired()
            .HasMaxLength(200);

        modelBuilder.Entity<Membresias>()
            .Property(m => m.Precio)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Membresias>()
            .Property(m => m.FechaVencimiento)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Membresias>()
            .HasOne(m => m.EstadoMembresia)
            .WithMany()
            .HasForeignKey(m => m.EstadoMembresiaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Datos iniciales de EstadosMembresia
        modelBuilder.Entity<EstadosMembresia>().HasData(
            new EstadosMembresia { EstadoMembresiaId = 1, Descripcion = "Activo" },
            new EstadosMembresia { EstadoMembresiaId = 2, Descripcion = "Suspendido" },
            new EstadosMembresia { EstadoMembresiaId = 3, Descripcion = "Vencido" }
        );

        // Datos iniciales de Membresías
        modelBuilder.Entity<Membresias>().HasData(
            new Membresias
            {
                MembresiaId = 1,
                Descripcion = "Membresía Estudiante",
                Precio = 500.00,
                FechaVencimiento = DateTime.Now.AddMonths(1),
                EstadoMembresiaId = 1
            },
            new Membresias
            {
                MembresiaId = 2,
                Descripcion = "Membresía Básica",
                Precio = 800.00,
                FechaVencimiento = DateTime.Now.AddMonths(1),
                EstadoMembresiaId = 1
            },
            new Membresias
            {
                MembresiaId = 3,
                Descripcion = "Membresía VIP",
                Precio = 1500.00,
                FechaVencimiento = DateTime.Now.AddMonths(1),
                EstadoMembresiaId = 1
            }
        );

        // Configuración de Dias
        modelBuilder.Entity<Dias>()
            .HasKey(d => d.DiaId);

        modelBuilder.Entity<Dias>().HasData(
            new Dias { DiaId = 1, Nombre = "Lunes" },
            new Dias { DiaId = 2, Nombre = "Martes" },
            new Dias { DiaId = 3, Nombre = "Miércoles" },
            new Dias { DiaId = 4, Nombre = "Jueves" },
            new Dias { DiaId = 5, Nombre = "Viernes" },
            new Dias { DiaId = 6, Nombre = "Sábado" },
            new Dias { DiaId = 7, Nombre = "Domingo" }
        );

        // Configuración de Horarios
        modelBuilder.Entity<Horarios>()
            .HasKey(h => h.HorarioId);

        modelBuilder.Entity<Horarios>().HasData(
            new Horarios { HorarioId = 1, HoraInicio = new TimeOnly(6, 0), HoraFin = new TimeOnly(7, 0) },
            new Horarios { HorarioId = 2, HoraInicio = new TimeOnly(7, 0), HoraFin = new TimeOnly(8, 0) },
            new Horarios { HorarioId = 3, HoraInicio = new TimeOnly(8, 0), HoraFin = new TimeOnly(9, 0) }
        );

        // Configuración de DiasHorarios
        modelBuilder.Entity<DiasHorarios>()
            .HasKey(dh => dh.DiaHorarioId);

        modelBuilder.Entity<DiasHorarios>()
            .HasOne(dh => dh.Dia)
            .WithMany(d => d.DiasHorarios)
            .HasForeignKey(dh => dh.DiaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DiasHorarios>()
            .HasOne(dh => dh.Horario)
            .WithMany(h => h.DiasHorarios)
            .HasForeignKey(dh => dh.HorarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DiasHorarios>().HasData(
            new DiasHorarios { DiaHorarioId = 1, DiaId = 1, HorarioId = 1 },
            new DiasHorarios { DiaHorarioId = 2, DiaId = 2, HorarioId = 2 },
            new DiasHorarios { DiaHorarioId = 3, DiaId = 3, HorarioId = 3 }
        );
    }
}
