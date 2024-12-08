using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Domain.DTO;

public class InscripcionesDto
{
	public int InscripcionId { get; set; }

    public int ClienteId { get; set; }
    public ClientesDto Cliente { get; set; }

    public int MembresiaId { get; set; }
    public MembresiasDto Membresia { get; set; }

	public DateTime FechaInscripcion { get; set; } = DateTime.Now;
	public double Precio { get; set; }
    public virtual ICollection<InscripcionesDetalleDto> InscripcionDetalle { get; set; } = new List<InscripcionesDetalleDto>();
}
