using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FitForge.Abstractions.Interfaces;
using FitForge.Data.DAL;
using FitForge.Data.Models;
using FitForge.Domain.DTO;
using Microsoft.EntityFrameworkCore;

namespace FitForge.Services.Services;

public class ItinerariosService : IItinerariosService
{
    private readonly ApplicationDbContext _context;

    public ItinerariosService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Existe(int itinerariosId)
    {
        return await _context.Itinerarios.AnyAsync(e => e.ItinerarioId == itinerariosId);
    }

    public async Task<bool> Insertar(ItinerariosDto itinerariosDto)
    {
        try
        {
            var itinerario = new Itinerarios()
            {
                ItinerarioId = itinerariosDto.ItinerarioId,
                ClaseId = itinerariosDto.ClaseId,
                DiaHorarioId = itinerariosDto.DiaHorarioId,
                EntrenadorId = itinerariosDto.EntrenadorId,
                Precio = itinerariosDto.Precio,
            };
            _context.Itinerarios.Add(itinerario);
            var guardo = await _context.SaveChangesAsync() > 0;
            itinerariosDto.ItinerarioId = itinerario.ItinerarioId;
            return guardo;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al guardar el itinerario: " + ex.Message);
        }
    }

    public async Task<bool> Modificar(ItinerariosDto itinerariosDto)
    {
        try
        {
            var itinerario = new Itinerarios()
            {
                ItinerarioId = itinerariosDto.ItinerarioId,
                ClaseId = itinerariosDto.ClaseId,
                DiaHorarioId = itinerariosDto.DiaHorarioId,
                EntrenadorId = itinerariosDto.EntrenadorId,
                Precio = itinerariosDto.Precio,
            };
            _context.Itinerarios.Update(itinerario);
            var guardo = await _context.SaveChangesAsync() > 0;
            return guardo;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al modificar el itinerario: " + ex.Message);
        }
    }


    public async Task<bool> Guardar(ItinerariosDto itinerariosDto)
    {
        if (!await Existe(itinerariosDto.ItinerarioId))
        {
            return await Insertar(itinerariosDto);
        }
        else
        {
            return await Modificar(itinerariosDto);
        }
    }

    public async Task<bool> Eliminar(int ItinerarioId)
    {
        return await _context.Itinerarios
            .Where(e => e.ItinerarioId == ItinerarioId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<ItinerariosDto> Buscar(int itinerarioId)
    {
        return await _context.Itinerarios
            .Include(t => t.Clase)
            .Include(t => t.DiaHorario)
                .ThenInclude(dh => dh.Dia) // Asegúrate de que la relación con Día está bien configurada
            .Include(t => t.DiaHorario.Horario) // Relación con Horario
            .Include(t => t.Entrenador)
            .Where(t => t.ItinerarioId == itinerarioId)
            .Select(t => new ItinerariosDto
            {
                ItinerarioId = t.ItinerarioId,
                ClaseId = t.ClaseId,
                DiaHorarioId = t.DiaHorarioId,
                EntrenadorId = t.EntrenadorId,
                Precio = t.Precio,

                Clase = new ClasesDto
                {
                    ClaseId = t.Clase.ClaseId,
                    Descripcion = t.Clase.Descripcion
                },
                DiaHorario = new DiasHorariosDto
                {
                    DiaHorarioId = t.DiaHorario.DiaHorarioId,
                    DiaId = t.DiaHorario.DiaId,
                    HorarioId = t.DiaHorario.HorarioId,
                    Dia = new DiasDto
                    {
                        DiaId = t.DiaHorario.Dia.DiaId,
                        Nombre = t.DiaHorario.Dia.Nombre
                    },
                    Horario = new HorariosDto
                    {
                        HorarioId = t.DiaHorario.Horario.HorarioId,
                        HoraInicio = t.DiaHorario.Horario.HoraInicio,
                        HoraFin = t.DiaHorario.Horario.HoraFin
                    },
                    // Generar un solo campo que combine el nombre del día con el horario
                    DiaHorarioDescripcion = $"{t.DiaHorario.Dia.Nombre} - {t.DiaHorario.Horario.HoraInicio:HH:mm} a {t.DiaHorario.Horario.HoraFin:HH:mm}"
                },
                Entrenador = new EntrenadoresDto
                {
                    EntrenadorId = t.Entrenador.EntrenadorId,
                    Nombres = t.Entrenador.Nombres // Datos descriptivos del entrenador
                }
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<ItinerariosDto>> Listar(Expression<Func<Itinerarios, bool>> criterio)
    {
        return await _context.Itinerarios
            .Include(t => t.Clase)
            .Include(t => t.DiaHorario)
                .ThenInclude(dh => dh.Dia)
            .Include(t => t.DiaHorario.Horario)
            .Include(t => t.Entrenador)
            .Where(criterio)
            .Select(t => new ItinerariosDto
            {
                ItinerarioId = t.ItinerarioId,
                ClaseId = t.ClaseId,
                DiaHorarioId = t.DiaHorarioId,
                EntrenadorId = t.EntrenadorId,
                Precio = t.Precio,

                // Proyección de la clase
                Clase = new ClasesDto
                {
                    ClaseId = t.Clase.ClaseId,
                    Descripcion = t.Clase.Descripcion,  // Aquí se mapea la descripción de la clase
                },

                // Proyección de la relación Día y Horario
                DiaHorario = new DiasHorariosDto
                {
                    DiaHorarioId = t.DiaHorario.DiaHorarioId,
                    DiaId = t.DiaHorario.DiaId,
                    HorarioId = t.DiaHorario.HorarioId,

                    Dia = new DiasDto
                    {
                        DiaId = t.DiaHorario.Dia.DiaId,
                        Nombre = t.DiaHorario.Dia.Nombre  // Aquí se mapea el nombre del día
                    },

                    Horario = new HorariosDto
                    {
                        HorarioId = t.DiaHorario.Horario.HorarioId,
                        HoraInicio = t.DiaHorario.Horario.HoraInicio,
                        HoraFin = t.DiaHorario.Horario.HoraFin
                    },

                    // Campo adicional para mostrar la descripción combinada de Día y Horario
                    DiaHorarioDescripcion = $"{t.DiaHorario.Dia.Nombre} - {t.DiaHorario.Horario.HoraInicio:HH:mm} a {t.DiaHorario.Horario.HoraFin:HH:mm}"
                },

                // Proyección del nombre del entrenador
                Entrenador = new EntrenadoresDto
                {
                    EntrenadorId = t.Entrenador.EntrenadorId,
                    Nombres = t.Entrenador.Nombres  // Aquí se mapea el nombre del entrenador
                }
            })
            .ToListAsync();
    }
}