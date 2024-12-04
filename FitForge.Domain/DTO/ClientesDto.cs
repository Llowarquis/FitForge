using Azure;

namespace FitForge.Domain.DTO;

public class ClientesDto
{
    public int ClienteId { get; set; }
    public string UserId { get; set; }
    public string Nombres { get; set; }
    public string Email { get; set; }
    public string? Telefono { get; set; }
    public string Cedula { get; set; }
    public int Pin { get; set; }
    public string? UrlFotoPerfil { get; set; }
    public DateOnly FechaNacimiento { get; set; }
    public ICollection<TarjetasDto> Tarjetas { get; set; } = new List<TarjetasDto>();
    public ICollection<InscripcionesDto> Inscripciones { get; set; } = new List<InscripcionesDto>();
	public ICollection<PagosDto> PagosEfectivo { get; set; } = new List<PagosDto>();
}
