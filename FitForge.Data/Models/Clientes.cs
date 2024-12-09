using FitForge.Data.DAL;
using FitForge.Data.Modelsp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Clientes
{
	[Key]
	public int ClienteId { get; set; }

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	[RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "Este campo solo puede contener letras y espacios.")]
	public string Nombres { get; set; }


	[RegularExpression(@"(^\d{3}-\d{7}-\d$)|(^\d{1,10}$)", ErrorMessage = "El valor debe ser una cédula válida (000-0000000-0) o un número.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string Cedula { get; set; }

	public string Email { get; set; }


	public int Pin { get; set; }


	public string? UrlFotoPerfil { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public DateOnly FechaNacimiento { get; set; }

	public ICollection<Tarjetas>? Tarjetas { get; set; } = new List<Tarjetas>();
	public ICollection<Inscripciones>? Inscripciones { get; set; } = new List<Inscripciones>();
    public ICollection<Pagos>? PagosEfectivo { get; set; } = new List<Pagos>();
}
