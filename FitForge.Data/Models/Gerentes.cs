using FitForge.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class Gerentes : Usuarios
{
	[Key]
	public int GerenteId { get; set; }

	public string Nombres { get; set; } = string.Empty;

    public Rol Rol{ get; set; }
}
