namespace FitForge.Domain.DTO;

public class PagosDto
{
	public int PagoId { get; set; }
	public TarjetasDto? Tarjeta { get; set; }
    public FormasPagoDto FormaPago { get; set; }
	public string NombreCliente { get; set; }
	public double Monto { get; set; }
	public DateTime FechaPago { get; set; } = DateTime.Now;
}
