using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Domicilios
{
    [Key]
    public int DomicilioId { get; set; }


	[RegularExpression(@"^[a-zA-Z0-9-ÁáÉéÍíÓóÚúÑñ\s]+$", ErrorMessage = "Este campo solo puede alojar letras, números, y símbolos comunes.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
    public string Calle { get; set; } = string.Empty;


	[RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Este campo solo puede alojar numeros.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int NumCasa { get; set; }


	[RegularExpression(@"^[a-zA-Z0-9-ÁáÉéÍíÓóÚúÑñ\s]+$", ErrorMessage = "Este campo solo puede alojar letras, números, y símbolos comunes.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string Sector { get; set; } = string.Empty;


	[RegularExpression(@"^[a-zA-Z0-9-ÁáÉéÍíÓóÚúÑñ\s]+$", ErrorMessage = "Este campo solo puede alojar letras, números, y símbolos comunes.")]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public string Provincia { get; set; } = string.Empty;


	[ForeignKey("Clientes")]
    public int ClienteId { get; set; }
    public Clientes Cliente { get; set; }
}
