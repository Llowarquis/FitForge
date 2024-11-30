using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class Articulos
{
	[Key]
	public int ArticuloId { get; set; }

    public string Descripcion { get; set; }

    public int Existencia { get; set; }

	public double Precio { get; set; }
}
