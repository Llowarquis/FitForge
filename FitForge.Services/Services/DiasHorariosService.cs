using FitForge.Abstractions.Interfaces;
using FitForge.Data.DAL;
using FitForge.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitForge.Services.Services;

public class DiasHorariosService(IDbContextFactory<ApplicationDbContext> DbFactory) : IDiasHorariosService
{
    public async Task<List<DiasHorariosDto>> ObtenerDiasHorariosAsync()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.DiasHorarios
            .Include(dh => dh.Dia)
            .Include(dh => dh.Horario)
            .Select(dh => new DiasHorariosDto
            {
                DiaHorarioId = dh.DiaHorarioId,
                DiaHorarioDescripcion = $"{dh.Dia.Nombre} - {dh.Horario.HoraInicio:HH:mm} a {dh.Horario.HoraFin:HH:mm}"
            })
            .ToListAsync();
    }

}