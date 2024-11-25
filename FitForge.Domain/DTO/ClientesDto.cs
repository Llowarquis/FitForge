using FitForge.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Domain.DTO;

public class ClientesDto
{
    public int ClienteId { get; set; }
    public string Nombres { get; set; } = string.Empty;
    public int Pin { get; set; }
    public ICollection<TarjetasDto>? Tarjeta { get; set; } = [];
	public ICollection<PagosEfectivoDto> PagoEfectivo { get; set; } = [];
	public DateOnly FechaNacimiento { get; set; }
    public EstadoMembresia Membresia { get; set; }
}
