using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitForge.Abstractions.Interfaces;
using FitForge.Domain.Dto;
using FitForge.Domain.Enums;
using FitForge.Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace FitForge.Services.Services
{
    public class MembresiasService : IMembresiasService
    {
        private readonly ApplicationDbContext _dbContext;

        public MembresiasService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MembresiasDto>> ObtenerMembresiasAsync()
        {

            var membresias = await _dbContext.Membresias
                .Include(m => m.EstadoMembresia)
                .ToListAsync();

            var membresiasDto = membresias.Select(m => new MembresiasDto
            {
                MembresiaId = m.MembresiaId,
                Descripcion = m.Descripcion,
                Precio = m.Precio,
                FechaVencimiento = m.FechaVencimiento,

                EstadoMembresia = (EstadoMembresiaDto)m.EstadoMembresia.EstadoMembresiaId
            }).ToList();

            return membresiasDto;
        }
    }
}