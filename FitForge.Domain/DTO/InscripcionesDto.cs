using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Domain.DTO;

public class InscripcionesDto
{
	public int InscripcionId { get; set; }
	public ClientesDto Cliente { get; set; }
	public MembresiasDto Membresia { get; set; }
	public ItinerariosDto Itinerario { get; set; }
	public DateTime FechaInscripcion { get; set; } = DateTime.Now;
	public double Precio { get; set; }
	public EntrenadoresDto Entrenador { get; set; }
}
