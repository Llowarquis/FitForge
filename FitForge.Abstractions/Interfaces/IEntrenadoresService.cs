using FitForge.Domain.DTO;

namespace FitForge.Abstractions.Interfaces;

public interface IEntrenadoresService
{
    Task<List<EntrenadoresDto>> ObtenerEntrenadoresAsync();
}
