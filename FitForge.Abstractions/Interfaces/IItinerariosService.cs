using FitForge.Data.Models;
using FitForge.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FitForge.Abstractions.Interfaces;

public interface IItinerariosService
{
    Task<bool> Guardar(ItinerariosDto itinerariosDto);
    Task<bool> Insertar(ItinerariosDto itinerariosDto);
    Task<bool> Modificar(ItinerariosDto itinerariosDto);
    Task<bool> Existe(int id);
    Task<bool> Eliminar(int id);
    Task<ItinerariosDto?> Buscar(int id);
    Task<List<ItinerariosDto>> Listar(Expression<Func<Itinerarios, bool>> criterio);
}
