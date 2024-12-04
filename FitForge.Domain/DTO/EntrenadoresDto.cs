namespace FitForge.Domain.DTO;

public class EntrenadoresDto
{
    public int EntrenadorId { get; set; }
    public string UserId { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Nombres { get; set; }
    public DateOnly FechaIngreso { get; set; }
	public string? UrlFotoPerfil { get; set; }


    // Los siguientes datos los proporciona ClasesDto
    public string? DescripcionClase { get; set; }
	public TimeOnly? HoraInicioClase { get; set; }
    public TimeOnly? HoraFinClase { get; set; }
    public List<string>? DiasClase { get; set; }
}
