using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Pagos
{
	[Key]
	public int PagoId { get; set; }


	[ForeignKey("Tarjetas")]
	public int TarjetaId { get; set; }
	public Tarjetas Tarjeta { get; set; }


	[ForeignKey("FormasPago")]
    public int FormasPagoId { get; set; }
    public FormasPago FormaPago { get; set; }


	[ForeignKey("Clientes")]
	public int ClienteId { get; set; }
	public Clientes Cliente { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
    public double Monto { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public DateTime FechaPago { get; set; } = DateTime.Now;
}
