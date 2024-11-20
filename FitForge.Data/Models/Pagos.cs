using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class Pagos
{
	[Key]
	public int PagoId { get; set; }


	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public double Monto { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public DateTime FechaPago { get; set; } = DateTime.UtcNow;
}
