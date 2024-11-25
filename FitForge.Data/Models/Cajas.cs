using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Cajas
{
	[Key] 
	public int CajaId { get; set; }

    public double BalanceEfectivo { get; set; }

    public double BalanceBanco { get; set; } 

    public ICollection<PagosEfectivo> PagosEfectivo { get; set; } = new List<PagosEfectivo>();

	public ICollection<PagosTarjeta> PagoTarjeta { get; set; } = new List<PagosTarjeta>();
}
