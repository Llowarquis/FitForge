﻿namespace FitForge.Domain.DTO;

public class TarjetasDto
{
    public int TarjetaId { get; set; }

    public int ClienteId { get; set; }
    public ClientesDto Cliente { get; set; }
	public string NumeroTarjeta { get; set; }
	public int Cvv { get; set; }
	public DateOnly FechaVencimiento { get; set; }
    public ICollection<PagosDto> Pagos { get; set; }
}
