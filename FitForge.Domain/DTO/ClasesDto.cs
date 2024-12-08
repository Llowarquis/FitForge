namespace FitForge.Domain.DTO;

public class ClasesDto
{
	public int ClaseId { get; set; }
    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public int Cupos { get; set; }

	// Esta fecha sera igual a la fecha de inscripcion mas 1 mes
	public DateTime FechaVencimiento { get; set; }
}
