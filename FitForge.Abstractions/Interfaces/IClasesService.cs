using FitForge.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitForge.Abstractions.Interfaces;

public interface IClasesService
{
    Task<List<ClasesDto>> ObtenerClasesAsync();
}
