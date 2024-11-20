using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Cajas
{
	[Key] 
	public int Id { get; set; }

    public double BalanceEfectivo { get; set; }

    public double BalanceBanco { get; set; } 


    [ForeignKey("Pagos")]
    public int PagoId { get; set; }
    public ICollection<Pagos> Pagos { get; set; } = new List<Pagos>();
}
