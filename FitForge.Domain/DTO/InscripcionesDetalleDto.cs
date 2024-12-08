using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitForge.Domain.DTO;

public class InscripcionesDetalleDto
{
    public int DetalleId { get; set; }

    public int InscripcionId { get; set; }

    public int ItinerarioId { get; set; }

    public int ClaseId { get; set; }

    public int DiaHorarioId { get; set; }

    public int EntrenadorId { get; set; }

    public double Precio { get; set; }
}