namespace FitForge.Domain.DTO;

public class TarjetasDto
{
	public int TarjetaId { get; set; }
	public int NumeroTarjeta { get; set; }
	public int Cvv { get; set; }
	public DateOnly? FechaVencimiento { get; set; } = null;
}
