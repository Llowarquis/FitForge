using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class HorariosDeClases
{
	[Key]
	public int HorarioDeClaseId { get; set; }

    public int ClaseId { get; set; }
    public Clases Clase { get; set; }

	public int DiaHorarioId { get; set; }
	public DiasHorarios DiaHorario { get; set; }
}
