using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitForge.Data.Models;

public class InscripcionesDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int InscripcionId { get; set; }

    public int ItinerarioId { get; set; }

    public int ClaseId { get; set; }

    public int DiaHorarioId { get; set; }

    public int EntrenadorId { get; set; }

    public double Precio { get; set; }

}