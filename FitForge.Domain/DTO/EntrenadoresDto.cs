using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class EntrenadoresDto
{
    public int EmpleadoId { get; set; }
	public int Nombres { get; set; }

	[ForeignKey("ClasesDto")]
	public int? ClaseId { get; set; }
    public ClasesDto Clase { get; set; }
}
