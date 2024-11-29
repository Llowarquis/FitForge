namespace FitForge.Data.Models;
public class DiasHorariosDto
{
	public int DiaHorarioId { get; set; }

    public int DiaId { get; set; }
    public DiasDto Dia { get; set; }

	public int HorarioId { get; set; }
	public HorariosDto Horario { get; set; }
}
