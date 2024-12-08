namespace FitForge.Domain.DTO;

public class InscripcionesDto
{
	public int InscripcionId { get; set; }

	// Cliente
	public int ClienteId { get; set; }
    public string NombreCliente { get; set; }

	// Entrenador
	public int? EntrenadorId { get; set; }
    public string? NombreEntrenador { get; set; }

	// Itinerario
	public int? ItinerarioId { get; set; }
    public string? NombreClase { get; set; }
    public string? DiaClase { get; set; }
	public TimeOnly? HoraInicioClase { get; set; }
	public TimeOnly? HoraFinClase { get; set; }
    public double PrecioClase { get; set; }

    // Membresia
    public string DescripcionMembresia { get; set; }

	public DateTime FechaInscripcion { get; set; } = DateTime.Now;

	// Este precio la suma del precio de la inscripcion de membresia, clases o entrenadores
	public double Precio { get; set; } 
}
