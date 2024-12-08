using FitForge.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Modelsp;

public class Inscripciones
{
	[Key]
	public int InscripcionId { get; set; }

	[ForeignKey("Clientes")]
	public int ClienteId { get; set; }
	public Clientes Cliente { get; set; }

	[ForeignKey("Membresias")]
	public int MembresiaId { get; set; }
	public Membresias Membresia { get; set; }

	public DateTime FechaInscripcion { get; set; } = DateTime.Now;

    public virtual ICollection<InscripcionesDetalle> InscripcionDetalle { get; set; } = new List<InscripcionesDetalle>();

    public double Precio { get; set; }
}
