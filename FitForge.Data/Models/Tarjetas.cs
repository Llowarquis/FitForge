using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Tarjetas
{
    [Key]
    public int TarjetaId { get; set; }


	[ForeignKey("Clientes")]
	public int ClienteId { get; set; }
	public Clientes Cliente { get; set; }
	

	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string NumeroTarjeta { get; set; }


	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int Cvv { get; set; }


	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public DateOnly FechaVencimiento { get; set; }


    public ICollection<Pagos> Pagos { get; set; }
}
