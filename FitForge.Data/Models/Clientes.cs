using FitForge.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Clientes : Usuarios
{
    [Key]
    public int ClienteId { get; set; }



    [RegularExpression(@"^[a-zA-Z-ÁáÉéÍíÓóÚúÑñ\s]+$", ErrorMessage = "Este campo solo puede alojar letras/espacios.")]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Nombres { get; set; } = string.Empty;



    [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public long Cedula { get; set; }


    // Este campo se debe asignar automaticamente cuando se cree en la DB y debe empezar en 1000 e ira de 1 en 1,
    // no se como se hara pero debe hacerse XD (cuando se logre se borra este comentario)
    public int Pin { get; set; }



	[ForeignKey("Tarjetas")]
	public Tarjetas? TarjetaId { get; set; }
    public ICollection<Tarjetas>? Tarjeta { get; set; } = new List<Tarjetas>();



    public string? FotoPerfilUrl { get; set; } // Se guarda la URL de la imagen para que ocupe menos espacio y sea mas rapida su accesibilidad



    public int? Telefono { get; set; }



    [Required]
    public Domicilios Domicilio { get; set; }



    [Required(ErrorMessage = "Este campo es obligatorio")]
    [ForeignKey("PagosEfectivo")]
	public int PagoEfectivoId { get; set; }
	public ICollection<PagosEfectivo> PagoEfectivo { get; set; } = new List<PagosEfectivo>();



    [Required(ErrorMessage = "Este campo es obligatorio")]
    public DateOnly FechaNacimiento { get; set; }



    public EstadoMembresia Membresia { get; set; }

}
