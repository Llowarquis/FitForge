using FitForge.Domain.DTO;
using FitForge.Data.Modelsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FitForge.Abstractions.Interfaces;

public interface IInscripcionesService
{
    Task<bool> Existe(int inscripcionId);
    Task<bool> Insertar(InscripcionesDto inscripcionesDto);

    Task AfectarInscripcion(InscripcionesDetalleDto[] detalle);

    Task<bool> Modificar(InscripcionesDto inscripcionesDto);

    Task<bool> Guardar(InscripcionesDto inscripcionesDto);

    Task<InscripcionesDto> Buscar(int id);

    Task<bool> Eliminar(int id);

    Task<List<InscripcionesDto>> Listar(Expression<Func<Inscripciones, bool>> criterio);

    Task<IEnumerable<InscripcionesDetalleDto>> ObtenerDetalles(int inscripcionId);
}
