using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class ReservaDeServicio
{
    public int IdReservaServicio { get; set; }

    public string? ObservacionRs { get; set; }

    public int? IdReservaRs { get; set; }

    public virtual Reserva? IdReservaRsNavigation { get; set; }

    public virtual ICollection<ReservaDss> ReservaDsses { get; set; } = new List<ReservaDss>();
}
