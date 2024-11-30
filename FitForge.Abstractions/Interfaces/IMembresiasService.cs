using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitForge.Domain.Dto;

namespace FitForge.Abstractions.Interfaces
{
    public interface IMembresiasService
    {
        Task<List<MembresiasDto>> GetMembresiasAsync();
    }
}
