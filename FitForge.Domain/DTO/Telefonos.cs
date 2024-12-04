using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Telefonos
{
	public int TelefonoId { get; set; }

    [ForeignKey("ClientesDto")]
    public int ClienteId { get; set; }
    public ClientesDto Cliente { get; set; }

    public int Telefono { get; set; }
}
