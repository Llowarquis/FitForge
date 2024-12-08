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

public class EstadosMembresiasService(IDbContextFactory<ApplicationDbContext> DbFactory) : IEstadoMembresiasService
{
    public async Task<List<EstadosMembresiaDto>> ObtenerEstadoMembresias()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.EstadosMembresia
            .Select(c => new EstadosMembresiaDto()
            {
                EstadoMembresiaId = c.EstadoMembresiaId,
                Descripcion = c.Descripcion,
            })
            .AsNoTracking().ToListAsync();
    }

}