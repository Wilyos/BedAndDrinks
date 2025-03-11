using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class Registro
{
    public int IdRegistro { get; set; }

    public DateOnly? FechaLlegada { get; set; }

    public DateOnly? FechaSalida { get; set; }

    public decimal? ValorTotal { get; set; }

    public int? IdReservaReg { get; set; }

    public int? IdHuespedReg { get; set; }

    public virtual Huespede? IdHuespedRegNavigation { get; set; }

    public virtual Reserva? IdReservaRegNavigation { get; set; }
}
