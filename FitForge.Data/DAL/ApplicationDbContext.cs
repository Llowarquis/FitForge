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
	public DbSet<Membresias> Membresias { get; set; }
	public DbSet<Pagos> Pagos { get; set; }
	public DbSet<Tarjetas> Tarjetas { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Esto es para que el Pin del cliente empiece en 1000 y siga de 1 en 1
		modelBuilder.Entity<Clientes>()
			.Property(u => u.Pin)
			.ValueGeneratedOnAdd()
			.HasDefaultValueSql("NEXT VALUE FOR Pin");

		modelBuilder.HasSequence<int>("Pin", schema: "dbo")
			.StartsAt(1000)
			.IncrementsBy(1);

		modelBuilder.Entity<Pagos>()
		.HasOne(p => p.Tarjeta)
		.WithMany(t => t.Pagos)
		.HasForeignKey(p => p.TarjetaId)
		.OnDelete(DeleteBehavior.Restrict); // Desactiva la cascada

		base.OnModelCreating(modelBuilder);
	}
}


