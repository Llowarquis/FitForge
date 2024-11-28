using FitForge.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Entrenadores
{
    [Key]
    public int EmpleadoId { get; set; }


	[RegularExpression(@"^[a-zA-Z-ÁáÉéÍíÓóÚúÑñ\s]+$", ErrorMessage = "Este campo solo puede alojar letras/espacios.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int Nombres { get; set; }


	[ForeignKey("Clases")]
	public int? ClaseId { get; set; }
    public Clases Clase { get; set; }
}
