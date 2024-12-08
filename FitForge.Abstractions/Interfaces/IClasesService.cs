using FitForge.Domain.DTO;
using System.Linq.Expressions;

namespace FitForge.Abstractions.Interfaces;

public interface IClasesService
{
	public Task<bool> Guardar(ClasesDto clasesDto);
	public Task<bool> Eliminar(int id);
	public Task<ClasesDto> Buscar(int id);
	public Task<List<ClasesDto>> Listar(Expression<Func<ClasesDto, bool>> criterio);
  public Task<List<ClasesDto>> ObtenerClasesAsync();
}
