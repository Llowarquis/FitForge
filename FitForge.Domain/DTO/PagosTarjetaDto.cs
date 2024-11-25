using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Domain.DTO;

public class PagosTarjetaDto
{
	public int PagoEfectivoId { get; set; }
	public double Monto { get; set; }
	public DateTime FechaPago { get; set; } = DateTime.UtcNow;
    public TarjetasDto Tarjeta { get; set; }
}
