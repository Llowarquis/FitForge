using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Domain.DTO;

public class DomiciliosDto
{
    public int DomicilioId { get; set; }
    public string Calle { get; set; }
	public int NumCasa { get; set; }
	public string Sector { get; set; }
	public string Provincia { get; set; }
    public ClientesDto Cliente { get; set; }
}
