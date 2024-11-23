using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitForge.Data.Models;

public class Cajas
{
	[Key] 
	public int Id { get; set; }

    public double BalanceEfectivo { get; set; }

    public double BalanceBanco { get; set; } 


    [ForeignKey("PagosEfectivo")]
    public int PagoEfectivoId { get; set; }
    public ICollection<PagosEfectivo> PagosEfectivo { get; set; } = new List<PagosEfectivo>();


	[ForeignKey("PagosTarjeta")]
	public int PagoTarjetaId { get; set; }
	public ICollection<PagosTarjeta> PagoTarjeta { get; set; } = new List<PagosTarjeta>();
}
