using FitForge.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Domain.DTO;

public class ClientesDto
{
    public int ClienteId { get; set; }
    public string Nombres { get; set; } = string.Empty;
    public int Pin { get; set; }

    [ForeignKey("TarjetasDto")]
    public int? TarjetaId { get; set; }
    public ICollection<TarjetasDto>? Tarjeta { get; set; } = [];

    [ForeignKey("PagosEfectivo")]
	public int PagoEfectivoId { get; set; }
	public ICollection<PagosEfectivoDto> PagoEfectivo { get; set; } = new List<PagosEfectivoDto>();
	public DateOnly FechaNacimiento { get; set; }
    public EstadoMembresiaDto Membresia { get; set; }
}
