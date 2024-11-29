using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Pagos
{
	public int PagoId { get; set; }


	[ForeignKey("TarjetasDto")]
	public int TarjetaId { get; set; }
	public Tarjetas Tarjeta { get; set; }


	[ForeignKey("FormasPagoDto")]
    public int FormasPagoId { get; set; }
    public FormasPagoDto FormaPago { get; set; }

    public double Monto { get; set; }
	public DateTime FechaPago { get; set; } = DateTime.Now;
}
