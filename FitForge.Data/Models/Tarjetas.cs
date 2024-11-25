using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class Tarjetas
{
    [Key]
    public int TarjetaId { get; set; }

	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int NumeroTarjeta { get; set; }


	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int Cvv { get; set; }


	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public DateOnly? FechaVencimiento { get; set; } = null;

	public ICollection<PagosTarjeta> PagoTarjeta { get; set; } = new List<PagosTarjeta>();
}
