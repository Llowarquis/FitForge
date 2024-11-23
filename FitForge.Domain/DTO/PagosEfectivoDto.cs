namespace FitForge.Domain.DTO;

public class PagosEfectivoDto
{
    public int PagoEfectivoId { get; set; }
	public double Monto { get; set; }
	public DateTime FechaPago { get; set; } = DateTime.UtcNow;
}
