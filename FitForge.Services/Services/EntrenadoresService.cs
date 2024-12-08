using FitForge.Abstractions.Interfaces;
using FitForge.Data.DAL;
using FitForge.Data.Models;
using FitForge.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace FitForge.Services.Services;

public class EntrenadoresService(IDbContextFactory<ApplicationDbContext> DbFactory) : IEntrenadoresService
{
	// Guardar
	public async Task<bool> Guardar(EntrenadoresDto entrenadorDto)
	{
		if (!await Existe(entrenadorDto.EntrenadorId))
			return await Insertar(entrenadorDto);
		else
			return await Modificar(entrenadorDto);
	}

	// Existe
	private async Task<bool> Existe(int id)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();
		return await _contexto.Entrenadores
							  .AnyAsync(e => e.EntrenadorId == id);
	}

	// Insertar
	private async Task<bool> Insertar(EntrenadoresDto entrenadorDto)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();

		// Verificar si el ApplicationUserId es válido
		var usuarioExiste = await _contexto.Users.AnyAsync(u => u.Id == entrenadorDto.UserId);
		if (!usuarioExiste)
		{
			throw new Exception("El usuario relacionado no existe en AspNetUsers.");
		}

		var entrenador = new Entrenadores()
		{
			EntrenadorId = entrenadorDto.EntrenadorId,
			Nombres = entrenadorDto.Nombres,
			ApplicationUserId = entrenadorDto.UserId,
			FechaIngreso = entrenadorDto.FechaIngreso,
			UrlFotoPerfil = entrenadorDto.UrlFotoPerfil
		};
		_contexto.Entrenadores.Add(entrenador);
		entrenadorDto.EntrenadorId = entrenador.EntrenadorId;
		return await _contexto.SaveChangesAsync() > 0;
	}

	// Modificar
	private async Task<bool> Modificar(EntrenadoresDto entrenadorDto)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();

		var entrenador = await _contexto.Entrenadores
			.Include(e => e.ApplicationUser)
			.FirstOrDefaultAsync(e => e.EntrenadorId == entrenadorDto.EntrenadorId);

		if (entrenador == null)
			throw new KeyNotFoundException("El entrenador no fue encontrado.");

		if (entrenador.ApplicationUser == null)
			throw new KeyNotFoundException("El usuario asociado al entrenador no fue encontrado.");

		entrenador.Nombres = entrenadorDto.Nombres;
		entrenador.FechaIngreso = entrenadorDto.FechaIngreso;
		entrenador.ApplicationUser.Email = entrenadorDto.Email;
		entrenador.ApplicationUser.PhoneNumber = entrenadorDto.Telefono;

		return await _contexto.SaveChangesAsync() > 0;
	}

	// Eliminar
	public async Task<bool> Eliminar(int id)
	{
		if (id <= 0)
			return false;

		await using var contexto = await DbFactory.CreateDbContextAsync();

		var existeEntrenador = await contexto.Entrenadores.AnyAsync(e => e.EntrenadorId == id);
		if (!existeEntrenador) return false;

		return await contexto.Entrenadores
			.Where(c => c.EntrenadorId == id)
			.ExecuteDeleteAsync() > 0;
	}


	// Buscar
	public async Task<EntrenadoresDto> Buscar(int id)
	{
		if (id <= 0)
			return new EntrenadoresDto();

		await using var _contexto = await DbFactory.CreateDbContextAsync();
		var registroEncontrado = await _contexto.Entrenadores
			.Where(x => x.EntrenadorId == id)
			.Select(x => new EntrenadoresDto
			{
				EntrenadorId = x.EntrenadorId,
				Nombres = x.Nombres,
				Email = x.ApplicationUser.Email,
				Telefono = x.ApplicationUser.PhoneNumber,
				UserId = x.ApplicationUserId,
				FechaIngreso = x.FechaIngreso,
			})
			.FirstOrDefaultAsync();
		return registroEncontrado ?? new EntrenadoresDto();
	}

	// Listar
	public async Task<List<EntrenadoresDto>> Listar(Expression<Func<EntrenadoresDto, bool>> criterio)
	{
		await using var _contexto = await DbFactory.CreateDbContextAsync();

		var entrenadorDto = await _contexto.Entrenadores
			.AsNoTracking()
			.Select(x => new EntrenadoresDto
			{
				EntrenadorId = x.EntrenadorId,
				Email = x.ApplicationUser.Email,
				Telefono = x.ApplicationUser.PhoneNumber,
				UserId = x.ApplicationUserId,
				FechaIngreso = x.FechaIngreso,
				Nombres = x.Nombres,
			})
			.Where(criterio)
			.ToListAsync();

		return entrenadorDto;
	}

	// Validar numero telefono
	public async Task<bool> ValidarTelefono(string telefono)
	{
		if (await ExisteTelefono(telefono))
			return false;

		string pattern = @"^[(]?[0-9]{0,9}[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}[)]?$";
		Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

		return regex.IsMatch(telefono);
	}

	private async Task<bool> ExisteTelefono(string telefono)
	{
		if (string.IsNullOrWhiteSpace(telefono))
			return true;

		await using var _contexto = await DbFactory.CreateDbContextAsync();
		return await _contexto.Users.AnyAsync(c => c.PhoneNumber == telefono);
	}

    public async Task<List<EntrenadoresDto>> ObtenerEntrenadoresAsync()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Entrenadores
            .Select(e => new EntrenadoresDto
            {
                EntrenadorId = e.EntrenadorId,
                Nombres = e.Nombres
            })
            .ToListAsync();
    }
}
