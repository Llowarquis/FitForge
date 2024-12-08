namespace FitForge.Domain.DTO;
public class DiasHorariosDto
{
	public int DiaHorarioId { get; set; }

    public int DiaId { get; set; }
    public string NombreDia { get; set; }

	public int HorarioId { get; set; }
	public TimeOnly HoraInicio { get; set; }
	public TimeOnly HoraFin { get; set; }
}
