using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;

public class Dias
{
	[Key]
	public int DiaId { get; set; }
    public string Dia { get; set; }
}
