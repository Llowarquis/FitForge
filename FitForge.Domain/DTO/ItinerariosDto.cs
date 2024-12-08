namespace FitForge.Domain.DTO;

public class ItinerariosDto
{
	// A esta clase es la que se le hara el registro de las clases disponibles

	public int ItinerarioId { get; set; }
    public string DescripcionClase { get; set; }
	public List<string> Dia { get; set; } = new List<string>();
    public TimeOnly HoraInicio { get; set; }
	public TimeOnly HoraFin{ get; set; }
	public string NombreEntrenador { get; set; }
}
