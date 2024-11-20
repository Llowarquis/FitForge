using FitForge.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class Usuarios
{
	[Key]
	public int UsuarioId { get; set; }


	[RegularExpression(@"^[a-zA-Z-ÁáÉéÍíÓóÚúÑñ\s]+$", ErrorMessage = "Este campo solo puede alojar letras/espacios.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string Email { get; set; } = string.Empty;


	[RegularExpression(@"^[a-zA-Z-ÁáÉéÍíÓóÚúÑñ\s]+$", ErrorMessage = "Este campo solo puede alojar letras/espacios.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string Password { get; set; } = string.Empty;

	[Required]
    public Rol Rol { get; set; }
}
