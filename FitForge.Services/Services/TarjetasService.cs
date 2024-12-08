using FitForge.Abstractions.Interfaces;
using FitForge.Data.DAL;
using FitForge.Data.Models;
using FitForge.Domain.DTO;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FitForge.Services.Services;

public class TarjetasService(IDbContextFactory<ApplicationDbContext> DbFactory) : ITarjetasService
{
    public async Task<bool> Existe(int TarjetaId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Tarjetas.AnyAsync(e => e.TarjetaId == TarjetaId);
    }

    public async Task<bool> Insertar(TarjetasDto tarjetasDto)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        try
        {
            var tarjeta = new Tarjetas()
            {
                TarjetaId = tarjetasDto.TarjetaId,
                ClienteId = tarjetasDto.ClienteId,
                NumeroTarjeta = tarjetasDto.NumeroTarjeta,
                Cvv = tarjetasDto.Cvv,
                FechaVencimiento = tarjetasDto.FechaVencimiento
            };
            _contexto.Tarjetas.Add(tarjeta);
            var guardo = await _contexto.SaveChangesAsync() > 0;
            tarjetasDto.TarjetaId = tarjeta.TarjetaId;
            return guardo;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al guardar la tarjeta: " + ex.Message);
        }
    }

    public async Task<bool> Modificar(TarjetasDto tarjetasDto)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        try
        {
            var tarjeta = new Tarjetas()
            {
                TarjetaId = tarjetasDto.TarjetaId,
                ClienteId = tarjetasDto.ClienteId,
                NumeroTarjeta = tarjetasDto.NumeroTarjeta,
                Cvv = tarjetasDto.Cvv,
                FechaVencimiento = tarjetasDto.FechaVencimiento
            };
            _contexto.Tarjetas.Update(tarjeta);
            var guardo = await _contexto.SaveChangesAsync() > 0;
            return guardo;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al guardar la tarjeta: " + ex.Message);
        }
    }



    public async Task<bool> Guardar(TarjetasDto tarjetasDto)
    {
        if (!await Existe(tarjetasDto.TarjetaId))
        {
            return await Insertar(tarjetasDto);
        }
        else
        {
            return await Modificar(tarjetasDto);
        }
    }

    public async Task<bool> Eliminar(int tarjetaId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Tarjetas
            .Where(e => e.TarjetaId == tarjetaId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<TarjetasDto> Buscar(int tarjetaId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Tarjetas
            .Include(t => t.Cliente)
            .Where(t => t.TarjetaId == tarjetaId)
            .Select(t => new TarjetasDto
            {
                TarjetaId = t.TarjetaId,
                ClienteId = t.ClienteId,
                NumeroTarjeta = t.NumeroTarjeta,
                Cvv = t.Cvv,
                FechaVencimiento = t.FechaVencimiento,
                Cliente = new ClientesDto
                {
                    ClienteId = t.Cliente.ClienteId,
                    Nombres = t.Cliente.Nombres
                }
            })
            .FirstOrDefaultAsync();
    }
    public async Task<List<TarjetasDto>> Listar(Expression<Func<Tarjetas, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Tarjetas
            .Include(t => t.Cliente)  // Incluir la relación con Cliente
            .Where(criterio)  // Aplicar el filtro directamente a la entidad Tarjetas
            .Select(t => new TarjetasDto()
            {
                TarjetaId = t.TarjetaId,
                ClienteId = t.ClienteId,
                NumeroTarjeta = t.NumeroTarjeta,
                Cvv = t.Cvv,
                FechaVencimiento = t.FechaVencimiento,
                Cliente = new ClientesDto  // Proyección de los datos del Cliente
                {
                    ClienteId = t.Cliente.ClienteId,
                    Nombres = t.Cliente.Nombres,  // Aquí se mapea el nombre del cliente
                }
            })
            .ToListAsync();
    }
}