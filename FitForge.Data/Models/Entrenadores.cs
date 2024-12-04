using FitForge.Data.DAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Entrenadores
{
	[Key]
	public int EntrenadorId { get; set; }


	[ForeignKey("ApplicationUser")]
	public string ApplicationUserId { get; set; }
	public ApplicationUser ApplicationUser { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	[RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "Este campo solo puede contener letras y espacios.")]
	public string Nombres { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public DateOnly FechaIngreso { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public string? UrlFotoPerfil { get; set; }
}
