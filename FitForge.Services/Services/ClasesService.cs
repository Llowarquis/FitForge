using FitForge.Abstractions.Interfaces;
using FitForge.Data.DAL;

using FitForge.Data.Models;
using System.Linq.Expressions;
using FitForge.Domain.DTO;
using Microsoft.EntityFrameworkCore;

namespace FitForge.Services.Services;

public class ClasesService(IDbContextFactory<ApplicationDbContext> DbFactory) : IClasesService
{
	//AfectarCupos
	public async Task AfectarCupos(int id)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();
    // FALTA IMPLEMENTAR LOGICA
		if (!await _contexto.Clases.AnyAsync(c => c.ClaseId == id))
			throw new Exception("La clase que busca no existe.");

		
	}

	// Guardar
	public async Task<bool> Guardar(ClasesDto claseDto)
	{
		if (!await Existe(claseDto.ClaseId))
			return await Insertar(claseDto);
		else
			return await Modificar(claseDto);
	}

	// Existe
	private async Task<bool> Existe(int id)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();
		return await _contexto.Clases
							  .AnyAsync(c => c.ClaseId == id);
	}

	// Insertar
	private async Task<bool> Insertar(ClasesDto claseDto)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();

		var clase = new Clases()
		{
			ClaseId = claseDto.ClaseId,
			Descripcion = claseDto.Descripcion,
			Cupos = claseDto.Cupos,
			Precio = claseDto.Precio,
		};
		_contexto.Clases.Add(clase);
		claseDto.ClaseId = clase.ClaseId;
		return await _contexto.SaveChangesAsync() > 0;
	}

	// Modificar
	private async Task<bool> Modificar(ClasesDto claseDto)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();

		var clase = await _contexto.Clases
			.FirstOrDefaultAsync(e => e.ClaseId == claseDto.ClaseId);

		if (clase == null)
			throw new KeyNotFoundException("La clase no fue encontrada.");

		clase.Descripcion = claseDto.Descripcion;
		clase.Cupos = claseDto.Cupos;
		clase.Precio = claseDto.Precio;

		return await _contexto.SaveChangesAsync() > 0;
	}

	// Eliminar
	public async Task<bool> Eliminar(int id)
	{
		if (id <= 0)
			return false;

		await using var _contexto = await DbFactory.CreateDbContextAsync();
		var clase = await _contexto.Clases
			.FirstOrDefaultAsync(x => x.ClaseId == id);

		if (clase == null) return false;

		_contexto.Clases.Remove(clase);
		return await _contexto.SaveChangesAsync() > 0;
	}


	// Buscar
	public async Task<ClasesDto> Buscar(int id)
	{
		if (id <= 0)
			return new ClasesDto();

		await using var _contexto = await DbFactory.CreateDbContextAsync();
		var registroEncontrado = await _contexto.Clases
			.Where(x => x.ClaseId == id)
			.Select(x => new ClasesDto
			{
				ClaseId = x.ClaseId,
				Descripcion = x.Descripcion,
				Cupos = x.Cupos,
				FechaVencimiento = x.FechaVencimiento,
				Precio = x.Precio,
			})
			.FirstOrDefaultAsync();
		return registroEncontrado ?? new ClasesDto();
	}

	// Listar
	public async Task<List<ClasesDto>> Listar(Expression<Func<ClasesDto, bool>> criterio)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();

		var claseDto = await _contexto.Clases
			.AsNoTracking()
			.Select(x => new ClasesDto
			{
				ClaseId = x.ClaseId,
				Descripcion = x.Descripcion,
				Cupos = x.Cupos,
				FechaVencimiento = x.FechaVencimiento,
				Precio = x.Precio,
			})
			.Where(criterio)
			.ToListAsync();

		return claseDto;
	}

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
