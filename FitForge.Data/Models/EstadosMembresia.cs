using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class EstadosMembresia
{
	[Key]
	public int EstadoMembresiaId { get; set; }
    public string Descripcion { get; set; }
}
