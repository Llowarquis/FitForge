using FitForge.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FitForge.Abstractions.Interfaces;

public interface IMembresiasService
{
    Task<bool> Guardar(MembresiasDto membresiasDto);
    Task<bool> Insertar(MembresiasDto membresiasDto);
    Task<bool> Modificar(MembresiasDto modbresiasDto);
    Task<bool> Existe(int id);
    Task<bool> Eliminar(int id);
    Task<MembresiasDto?> Buscar(int id);
    Task<List<MembresiasDto>> Listar(Expression<Func<MembresiasDto, bool>> criterio);

    Task<List<MembresiasDto>> ObtenerMembresiasAsync();
}
