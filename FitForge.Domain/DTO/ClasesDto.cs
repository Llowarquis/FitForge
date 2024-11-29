namespace FitForge.Data.Models;

public class ClasesDto
{
	public int ClaseId { get; set; }
    public EntrenadoresDto Entrenador { get; set; }
    public string Descripcion { get; set; }
	public int Cupos { get; set; }
    public DateTime FechaVencimiento { get; set; } = DateTime.Now.AddMonths(1);
}
