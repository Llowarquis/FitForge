using FitForge.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class Usuarios
{
	[RegularExpression(@"^[a-zA-Z-ÁáÉéÍíÓóÚúÑñ\s]+$", ErrorMessage = "Este campo solo puede alojar letras/espacios.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string Email { get; set; }


	[RegularExpression(@"^[a-zA-Z-ÁáÉéÍíÓóÚúÑñ\s]+$", ErrorMessage = "Este campo solo puede alojar letras/espacios.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string Password { get; set; }

	[Required]
    public Rol Rol { get; set; }
}
