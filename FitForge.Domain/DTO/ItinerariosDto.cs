namespace FitForge.Domain.DTO;

public class ItinerariosDto
{
	public int ItinerarioId { get; set; }
    public string NombreClase { get; set; }
	public List<string> Dia { get; set; } = new List<string>();
    public TimeOnly HoraInicio { get; set; }
	public TimeOnly HoraFin{ get; set; }
	public string NombreEntrenador { get; set; }
}
