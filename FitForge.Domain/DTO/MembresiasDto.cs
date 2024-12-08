using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Domain.DTO;

public class MembresiasDto
{
	public int MembresiaId { get; set; }

    public int EstadoMembresiaId { get; set; }
    public EstadosMembresiaDto EstadoMembresia { get; set; }
    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public DateTime FechaVencimiento { get; set; } = DateTime.Now.AddMonths(1);
}
