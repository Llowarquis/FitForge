namespace FitForge.Domain.DTO;

public class ClasesDto
{
	public int ClaseId { get; set; }
    public string NombreEntrenador { get; set; }
    public string Descripcion { get; set; }
	public int Cupos { get; set; }
    public DateTime FechaVencimiento { get; set; }
}
