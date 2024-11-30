using FitForge.Data.Models;
using FitForge.Domain.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Modelsp;

public class InscripcionesDto
{	public int InscripcionId { get; set; }

	[ForeignKey("ClientesDto")]
	public int ClienteId { get; set; }
	public ClientesDto Cliente { get; set; }

	[ForeignKey("MembresiasDto")]
	public int MembresiaId { get; set; }
	public MembresiasDto Membresia { get; set; }

	[ForeignKey("HorariosDeClasesDto")]
	public int HorarioDeClaseId { get; set; }
	public HorariosDeClases HorarioDeClase { get; set; }

	public DateTime FechaInscripcion { get; set; } = DateTime.Now;

    public double Precio { get; set; }

	[ForeignKey("EntrenadoresDto")]
	public int EntrenadorId { get; set; }
	public EntrenadoresDto Entrenador { get; set; }
}
