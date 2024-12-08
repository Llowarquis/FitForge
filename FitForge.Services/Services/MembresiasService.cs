using FitForge.Abstractions.Interfaces;
using FitForge.Data.DAL;
using FitForge.Data.Models;
using FitForge.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FitForge.Services.Services;

public class MembresiasService(IDbContextFactory<ApplicationDbContext> DbFactory) : IMembresiasService
{
    public async Task<bool> Existe(int MembresiaId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Membresias.AnyAsync(e => e.MembresiaId == MembresiaId);
    }

    public async Task<bool> Insertar(MembresiasDto membresiasDto)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        try
        {
            var membresia = new Membresias()
            {
                MembresiaId = membresiasDto.MembresiaId,
                EstadoMembresiaId = membresiasDto.EstadoMembresiaId,
                Descripcion = membresiasDto.Descripcion,
                Precio = membresiasDto.Precio,
                FechaVencimiento = membresiasDto.FechaVencimiento
            };
            _contexto.Membresias.Add(membresia);
            var guardo = await _contexto.SaveChangesAsync() > 0;
            membresiasDto.MembresiaId = membresia.MembresiaId;
            return guardo;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al guardar la membresia: " + ex.Message);
        }
    }

    public async Task<bool> Modificar(MembresiasDto membresiasDto)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        try
        {
            var membresia = new Membresias()
            {
                MembresiaId = membresiasDto.MembresiaId,
                EstadoMembresiaId = membresiasDto.EstadoMembresiaId,
                Descripcion = membresiasDto.Descripcion,
                Precio = membresiasDto.Precio,
                FechaVencimiento = membresiasDto.FechaVencimiento
            };
            _contexto.Membresias.Update(membresia);
            var modificado = await _contexto.SaveChangesAsync() > 0;
            return modificado;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al guardar la membresia: " + ex.Message);
        }
    }



    public async Task<bool> Guardar(MembresiasDto membresiasDto)
    {
        if (!await Existe(membresiasDto.MembresiaId))
        {
            return await Insertar(membresiasDto);
        }
        else
        {
            return await Modificar(membresiasDto);
        }
    }

    public async Task<bool> Eliminar(int membresiasId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Membresias
            .Where(e => e.MembresiaId == membresiasId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<MembresiasDto> Buscar(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        var membresia = await _contexto.Membresias
            .Where(e => e.MembresiaId == id)
            .Select(e => new MembresiasDto()
            {
                MembresiaId = e.MembresiaId,
                EstadoMembresiaId = e.EstadoMembresiaId,
                Descripcion = e.Descripcion,
                Precio = e.Precio,
                FechaVencimiento = e.FechaVencimiento
            }).FirstOrDefaultAsync();

        return membresia ?? new MembresiasDto();

    }

    public async Task<List<MembresiasDto>> Listar(Expression<Func<MembresiasDto, bool>> criterio)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Membresias
            .Select(c => new MembresiasDto()
            {
                MembresiaId = c.MembresiaId,
                EstadoMembresiaId = c.EstadoMembresiaId,
                Descripcion = c.Descripcion,
                Precio = c.Precio,
                FechaVencimiento = c.FechaVencimiento,
                EstadoMembresia = new EstadosMembresiaDto
                {
                    EstadoMembresiaId = c.EstadoMembresia.EstadoMembresiaId,
                    Descripcion = c.EstadoMembresia.Descripcion
                }
            })
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<List<MembresiasDto>> ObtenerMembresiasAsync()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Membresias
            .Select(c => new MembresiasDto
            {
                MembresiaId = c.MembresiaId,
                Descripcion = c.Descripcion,


            })
            .ToListAsync();
    }


}
