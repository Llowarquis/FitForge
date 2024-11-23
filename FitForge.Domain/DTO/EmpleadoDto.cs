namespace FitForge.Domain.DTO;

public class EmpleadoDto
{
	public int EmpleadoId { get; set; }
	public int Nombres { get; set; }
	public string Cargo { get; set; } = string.Empty;
	public double Sueldo { get; set; }
}
