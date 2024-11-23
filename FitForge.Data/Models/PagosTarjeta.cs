using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class PagosTarjeta
{
	[Key]
	public int PagoTarjetaId { get; set; }

	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public double Monto { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public DateTime FechaPago { get; set; } = DateTime.UtcNow;


    [ForeignKey("PagosTarjeta")]
    public int TarjetaId { get; set; }
    public Tarjetas Tarjetas { get; set; }
}
