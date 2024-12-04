using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class Itinerarios
{
	[Key]
	public int ItinerarioId { get; set; }

    public int ClaseId { get; set; }
    public Clases Clase { get; set; }

	public int DiaHorarioId { get; set; }
	public DiasHorarios DiaHorario { get; set; }

    public int EntrenadorId { get; set; }
    public Entrenadores Entrenador { get; set; }
}
