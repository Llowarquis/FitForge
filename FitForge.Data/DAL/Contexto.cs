using FitForge.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitForge.Data.DAL;

public class Contexto : DbContext
{
	Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Cajas> Cajas { get; set; }

	public DbSet<Clientes> Clientes { get; set; }

	public DbSet<Domicilios> Domicilios { get; set; }

	public DbSet<Empleados> Empleados { get; set; }

	public DbSet<Gerentes> Gerentes { get; set; }

	public DbSet<Tarjetas> Tarjetas { get; set; }

	public DbSet<Usuarios> Usuarios { get; set; }
}
