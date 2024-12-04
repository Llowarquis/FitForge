using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Tarjetas
{
    public int TarjetaId { get; set; }


	[ForeignKey("ClientesDto")]
	public int ClienteId { get; set; }
	public ClientesDto Cliente { get; set; }


	public int NumeroTarjeta { get; set; }
	public int Cvv { get; set; }
	public DateOnly FechaVencimiento { get; set; }
    public ICollection<Pagos> Pagos { get; set; }
}
