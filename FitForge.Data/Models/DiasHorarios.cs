using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;
public class DiasHorarios
{
	[Key]
	public int DiaHorarioId { get; set; }

    public int DiaId { get; set; }
	public ICollection<Dias> Dias { get; set; } = new List<Dias>();

	public int HorarioId { get; set; }
	public ICollection<Horarios> Horario { get; set; } = new List<Horarios>();
}
