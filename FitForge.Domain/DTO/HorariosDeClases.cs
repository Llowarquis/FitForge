namespace FitForge.Data.Models;

public class HorariosDeClases
{
	public int HorarioDeClaseId { get; set; }

    public int ClaseId { get; set; }
    public ClasesDto Clase { get; set; }

	public int DiaHorarioId { get; set; }
	public DiasHorariosDto DiaHorario { get; set; }
}
