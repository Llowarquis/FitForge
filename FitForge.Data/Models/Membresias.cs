using FitForge.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Membresias
{
	[Key]
	public int MembresiaId { get; set; }

	[ForeignKey("EstadoMembresia")]
    public int EstadoMembresiaId { get; set; }
    public EstadosMembresia EstadoMembresia { get; set; }

    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public DateTime FechaVencimiento { get; set; } = DateTime.Now.AddMonths(1);
}
