namespace FitForge.Domain.DTO;
public class DiasHorariosDto
{
	  public int DiaHorarioId { get; set; }

    public int DiaId { get; set; }
    public string NombreDia { get; set; }

	  public int HorarioId { get; set; }
	  public HorariosDto Horario { get; set; }

    public string DiaHorarioDescripcion { get; set; }
}
