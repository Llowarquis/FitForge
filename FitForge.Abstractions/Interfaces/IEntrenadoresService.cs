using FitForge.Domain.DTO;
using System.Linq.Expressions;


namespace FitForge.Abstractions.Interfaces;

public interface IEntrenadoresService
{
	public Task<bool> Guardar(EntrenadoresDto entrenadorDto);
	public Task<bool> Eliminar(int id);
	public Task<EntrenadoresDto> Buscar(int id);
	public Task<List<EntrenadoresDto>> Listar(Expression<Func<EntrenadoresDto, bool>> criterio);
  public Task<List<EntrenadoresDto>> ObtenerEntrenadoresAsync();
}
