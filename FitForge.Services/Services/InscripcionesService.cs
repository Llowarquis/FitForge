using FitForge.Abstractions.Interfaces;
using FitForge.Data.DAL;
using FitForge.Data.Models;
using FitForge.Data.Modelsp;
using FitForge.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FitForge.Services.Services;

public class InscripcionesService(IDbContextFactory<ApplicationDbContext> DbFactory) : IInscripcionesService
{

    // Método para verificar si la inscripción existe
    public async Task<bool> Existe(int inscripcionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Inscripciones.AnyAsync(i => i.InscripcionId == inscripcionId);
    }

    // Insertar nueva inscripción
    public async Task<bool> Insertar(InscripcionesDto inscripcionDto)
    {
        try
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();

            // Crear la entidad principal (Inscripciones)
            var inscripcion = new Inscripciones
            {
                ClienteId = inscripcionDto.ClienteId,
                MembresiaId = inscripcionDto.MembresiaId,
                FechaInscripcion = inscripcionDto.FechaInscripcion,
                Precio = inscripcionDto.Precio
            };

            // Agregar la inscripción a la base de datos
            contexto.Inscripciones.Add(inscripcion);
            await contexto.SaveChangesAsync();

            // Asignar el ID generado a la DTO
            inscripcionDto.InscripcionId = inscripcion.InscripcionId;

            // Crear y agregar los detalles relacionados
            foreach (var detalleDto in inscripcionDto.InscripcionDetalle)
            {
                var detalle = new InscripcionesDetalle
                {
                    InscripcionId = inscripcion.InscripcionId,
                    ItinerarioId = detalleDto.ItinerarioId,
                    ClaseId = detalleDto.ClaseId,
                    DiaHorarioId = detalleDto.DiaHorarioId,
                    EntrenadorId = detalleDto.EntrenadorId,
                    Precio = detalleDto.Precio
                };

                contexto.InscripcionesDetalle.Add(detalle);
            }

            // Guardar los detalles en la base de datos
            var resultado = await contexto.SaveChangesAsync() > 0;
            return resultado;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al guardar la inscripción y sus detalles: " + ex.Message);
        }
    }


    public async Task AfectarInscripcion(InscripcionesDetalleDto[] detalle)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        foreach (var item in detalle)
        {
            var itinerario = await contexto.Itinerarios.SingleAsync(t => t.ItinerarioId == item.ItinerarioId);
        }
    }


    // Modificar inscripción existente
    public async Task<bool> Modificar(InscripcionesDto inscripcionDto)
    {
        try
        {
            var inscripcion = new Inscripciones
            {
                InscripcionId = inscripcionDto.InscripcionId,
                ClienteId = inscripcionDto.ClienteId,
                MembresiaId = inscripcionDto.MembresiaId,
                FechaInscripcion = inscripcionDto.FechaInscripcion,
                Precio = inscripcionDto.Precio,
            };

            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Inscripciones.Update(inscripcion);
            var result = await contexto.SaveChangesAsync() > 0;
            return result;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al modificar la inscripción: " + ex.Message);
        }
    }

    // Guardar (Insertar o Modificar) inscripción
    public async Task<bool> Guardar(InscripcionesDto inscripcionDto)
    {
        if (!await Existe(inscripcionDto.InscripcionId))
        {
            return await Insertar(inscripcionDto);
        }
        else
        {
            return await Modificar(inscripcionDto);
        }
    }

    // Eliminar inscripción
    public async Task<bool> Eliminar(int inscripcionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Inscripciones
            .Where(i => i.InscripcionId == inscripcionId)
            .ExecuteDeleteAsync() > 0;
    }

    // Buscar inscripción por ID
    public async Task<InscripcionesDto> Buscar(int inscripcionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Inscripciones
            .Include(i => i.Cliente)
            .Include(i => i.Membresia)
            .Where(i => i.InscripcionId == inscripcionId)
            .Select(i => new InscripcionesDto
            {
                InscripcionId = i.InscripcionId,
                ClienteId = i.ClienteId,
                MembresiaId = i.MembresiaId,
                FechaInscripcion = i.FechaInscripcion,
                Precio = i.Precio,

                Cliente = new ClientesDto
                {
                    ClienteId = i.Cliente.ClienteId,
                    Nombres = i.Cliente.Nombres
                },
                Membresia = new MembresiasDto
                {
                    MembresiaId = i.Membresia.MembresiaId,
                    Descripcion = i.Membresia.Descripcion
                },
            })
            .FirstOrDefaultAsync();
    }

    // Listar inscripciones según un criterio
    public async Task<List<InscripcionesDto>> Listar(Expression<Func<Inscripciones, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Inscripciones
            .Include(i => i.Cliente)
            .Include(i => i.Membresia)
            .Where(criterio)
            .Select(i => new InscripcionesDto
            {
                InscripcionId = i.InscripcionId,
                ClienteId = i.ClienteId,
                MembresiaId = i.MembresiaId,
                FechaInscripcion = i.FechaInscripcion,
                Precio = i.Precio,

                Cliente = new ClientesDto
                {
                    ClienteId = i.Cliente.ClienteId,
                    Nombres = i.Cliente.Nombres
                },
                Membresia = new MembresiasDto
                {
                    MembresiaId = i.Membresia.MembresiaId,
                    Descripcion = i.Membresia.Descripcion
                },
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<InscripcionesDetalleDto>> ObtenerDetalles(int inscripcionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var detalles = await contexto.InscripcionesDetalle
            .Where(d => d.InscripcionId == inscripcionId)
            .Select(d => new InscripcionesDetalleDto
            {
                ItinerarioId = d.ItinerarioId,
                ClaseId = d.ClaseId,
                DiaHorarioId = d.DiaHorarioId,
                EntrenadorId = d.EntrenadorId,
                Precio = d.Precio
            })
            .ToListAsync();

        return detalles;
    }
}

