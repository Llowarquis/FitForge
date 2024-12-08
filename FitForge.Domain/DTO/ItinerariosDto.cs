namespace FitForge.Domain.DTO;

public class ItinerariosDto
{
    public int ItinerarioId { get; set; }

    public int ClaseId { get; set; }
    public ClasesDto Clase { get; set; }

    public int DiaHorarioId { get; set; }
    public DiasHorariosDto DiaHorario { get; set; }

    public int EntrenadorId { get; set; }
    public EntrenadoresDto Entrenador { get; set; }

    public double Precio { get; set; }
}
