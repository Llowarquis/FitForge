using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class Horarios
{
	[Key]
	public int HorarioId { get; set; }
    public TimeOnly HoraInicio { get; set; }
    public TimeOnly HoraFin { get; set; }

    public ICollection<DiasHorarios> DiasHorarios { get; set; } = new List<DiasHorarios>();
}
