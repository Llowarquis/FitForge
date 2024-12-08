using FitForge.Abstractions.Interfaces;
using FitForge.Data.DAL;
using FitForge.Domain.DTO;
using Microsoft.EntityFrameworkCore;

namespace FitForge.Services.Services;

public class ClasesService(IDbContextFactory<ApplicationDbContext> DbFactory) : IClasesService
{

    public async Task<List<ClasesDto>> ObtenerClasesAsync()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Clases
            .Select(c => new ClasesDto
            {
                ClaseId = c.ClaseId,
                Descripcion = c.Descripcion,


            })
            .ToListAsync();
    }

}