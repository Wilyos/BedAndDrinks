using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class ReservaHabitacion
{
    public int IdReservaHabitacion { get; set; }

    public int? IdHabitacionRh { get; set; }

    public int? IdReservaRh { get; set; }

    public virtual Habitacion? IdHabitacionRhNavigation { get; set; }

    public virtual Reserva? IdReservaRhNavigation { get; set; }
}
