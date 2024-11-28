using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Telefonos
{
	[Key]
	public int TelefonoId { get; set; }

    [ForeignKey("Clientes")]
    public int ClienteId { get; set; }
    public Clientes Cliente { get; set; }

    public int Telefono { get; set; }
}
