using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Domain.DTO;

public class PagosTarjetaDto
{
	public int PagoEfectivoId { get; set; }
	public double Monto { get; set; }
	public DateTime FechaPago { get; set; } = DateTime.UtcNow;

    [ForeignKey("TarjetasDto")]
    public int TarjetaId { get; set; }
    public TarjetasDto Tarjeta { get; set; }
}
