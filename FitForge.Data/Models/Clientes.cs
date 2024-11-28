using FitForge.Data.Modelsp;
using FitForge.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }


    [RegularExpression(@"^[a-zA-Z-ÁáÉéÍíÓóÚúÑñ\s]+$", ErrorMessage = "Este campo solo puede alojar letras/espacios.")]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Nombres { get; set; } = string.Empty;


    [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public int Cedula { get; set; }


    // Este campo se debe asignar automaticamente cuando se cree en la DB y debe empezar en 1000 e ira de 1 en 1,
    // no se como se hara pero debe hacerse XD (cuando se logre se borra este comentario)
    public int Pin { get; set; }


    public string? UrlFotoPerfil { get; set; }


    [Required(ErrorMessage = "Este campo es obligatorio")]
    public DateOnly FechaNacimiento { get; set; }

    public ICollection<Tarjetas> Tarjetas { get; set; } = new List<Tarjetas>();
	public ICollection<Telefonos> Telefonos { get; set; } = new List<Telefonos>();
	public ICollection<Inscripciones> Inscripciones { get; set; } = new List<Inscripciones>();
}
