using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class ReservaDePaquete
{
    public int IdReservaDePaquetes { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? IdPaqueteRdp { get; set; }

    public virtual Paquete? IdPaqueteRdpNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
