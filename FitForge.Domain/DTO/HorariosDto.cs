namespace FitForge.Data.Models;

public class HorariosDto
{
	public int HorarioId { get; set; }
    public TimeOnly HoraInicio { get; set; }
    public TimeOnly HoraFin { get; set; }
}
