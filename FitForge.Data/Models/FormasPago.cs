using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class FormasPago
{
	[Key]
	public int FormasPagoId { get; set; }
    public string Descripcion{ get; set; }
}
