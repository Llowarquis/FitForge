namespace FitForge.Domain.DTO;

public class UsuariosDto
{
	public int UsuarioId { get; set; }
    public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
}
