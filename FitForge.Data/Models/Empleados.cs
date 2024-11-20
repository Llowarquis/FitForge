using FitForge.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class Empleados : Usuarios
{
    [Key]
    public int EmpleadoId { get; set; }

    public int Pin { get; set; }

	[RegularExpression(@"^[a-zA-Z-ÁáÉéÍíÓóÚúÑñ\s]+$", ErrorMessage = "Este campo solo puede alojar letras/espacios.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int Nombres { get; set; }


    [RegularExpression(@"^[a-zA-Z-ÁáÉéÍíÓóÚúÑñ\s]+$", ErrorMessage = "Este campo solo puede alojar letras/espacios.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string Cargo { get; set; } = string.Empty;


	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public double Sueldo { get; set; }
}
