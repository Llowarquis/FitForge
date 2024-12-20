﻿using System.ComponentModel.DataAnnotations;

namespace FitForge.Data.Models;
public class DiasHorarios
{
	[Key]
	public int DiaHorarioId { get; set; }

    public int DiaId { get; set; }
    public Dias Dia { get; set; }

    public int HorarioId { get; set; }
    public Horarios Horario { get; set; }
}
