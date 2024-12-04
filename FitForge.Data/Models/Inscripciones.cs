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

	[ForeignKey("Itinerarios")]
	public int? ItinerarioId { get; set; }
	public Itinerarios? Itinerario { get; set; }

	public DateTime FechaInscripcion { get; set; } = DateTime.Now;

    public double Precio { get; set; }

	[ForeignKey("Entrenadores")]
	public int? EntrenadorId { get; set; }
	public Entrenadores? Entrenador { get; set; }
}
