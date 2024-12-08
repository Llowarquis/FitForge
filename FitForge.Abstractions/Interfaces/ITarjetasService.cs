using FitForge.Data.Models;
using FitForge.Domain.DTO;
using System.Linq.Expressions;

namespace FitForge.Abstractions.Interfaces;

public interface ITarjetasService
{
    Task<bool> Guardar(TarjetasDto tarjetasDto);
    Task<bool> Insertar(TarjetasDto tarjetasDto);
    Task<bool> Modificar(TarjetasDto tarjetasDto);
    Task<bool> Existe(int id);
    Task<bool> Eliminar(int id);
    Task<TarjetasDto?> Buscar(int id);
    Task<List<TarjetasDto>> Listar(Expression<Func<Tarjetas, bool>> criterio);
}
