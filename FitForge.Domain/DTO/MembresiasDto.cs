using System.ComponentModel.DataAnnotations.Schema;
using FitForge.Domain.Enums;

namespace FitForge.Domain.Dto;

public class MembresiasDto
{
	public int MembresiaId { get; set; }

	[ForeignKey("EstadoMembresiaDto")]
    public int EstadoMembresiaId { get; set; }
    public EstadoMembresiaDto EstadoMembresia { get; set; }

    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public DateTime FechaVencimiento { get; set; } = DateTime.Now.AddMonths(1);
}
