using FitForge.Data.Modelsp;
using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class ClientesDto
{
    public int ClienteId { get; set; }
    public string Nombres { get; set; } = string.Empty;
    public int Cedula { get; set; }
    public int Pin { get; set; }
    public string? UrlFotoPerfil { get; set; }
    public DateOnly FechaNacimiento { get; set; }
    public ICollection<Tarjetas> Tarjetas { get; set; } = new List<Tarjetas>();
	public ICollection<Telefonos> Telefonos { get; set; } = new List<Telefonos>();
	public ICollection<InscripcionesDto> Inscripciones { get; set; } = new List<InscripcionesDto>();
}
