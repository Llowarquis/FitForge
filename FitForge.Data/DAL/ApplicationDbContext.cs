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
	public DbSet<HorariosDeClases> HorariosDeClases { get; set; }
	public DbSet<Inscripciones> Inscripciones { get; set; }
	public DbSet<Membresias> Membresias { get; set; }
	public DbSet<Pagos> Pagos { get; set; }
	public DbSet<Tarjetas> Tarjetas { get; set; }
	public DbSet<Telefonos> Telefonos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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
            .HasDefaultValue(DateTime.Now.AddMonths(1));

        modelBuilder.Entity<Membresias>()
            .HasOne(m => m.EstadoMembresia)
            .WithMany()
            .HasForeignKey(m => m.EstadoMembresiaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EstadosMembresia>().HasData(
            new EstadosMembresia { EstadoMembresiaId = 1, Descripcion = "Activo" },
            new EstadosMembresia { EstadoMembresiaId = 2, Descripcion = "Suspendido" },
            new EstadosMembresia { EstadoMembresiaId = 3, Descripcion = "Vencido" }
        );

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
    }
}
