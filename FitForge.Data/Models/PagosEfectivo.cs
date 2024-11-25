using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class PagosEfectivo
{
	[Key]
	public int PagoEfectivoId { get; set; }


	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public double Monto { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	public DateTime FechaPago { get; set; } = DateTime.UtcNow;


	[ForeignKey("CajasId")]
	public Cajas Caja { get; set; }

    [ForeignKey("ClienteId")]
    public Clientes Cliente { get; set; }
}
