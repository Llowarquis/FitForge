using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Clases
{
	[Key]
	public int ClaseId { get; set; }

    public Entrenadores Entrenador { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
    public string Descripcion { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	public int Cupos { get; set; }


	[Required(ErrorMessage = "Este campo es obligatorio")]
    public DateTime FechaVencimiento { get; set; } = DateTime.Now.AddMonths(1);
}
