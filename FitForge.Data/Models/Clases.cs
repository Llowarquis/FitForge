using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class Clases
{
	[Key]
	public int ClaseId { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
    public string Descripcion { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	public int Cupos { get; set; }

    public double Precio { get; set; }

    public DateTime FechaVencimiento { get; set; }
}
