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
}
