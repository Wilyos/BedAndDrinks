using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class ReservaDss
{
    public int IdreservaDds { get; set; }

    public int? IdReservaServiciosRdss { get; set; }

    public int? IdServicioRdds { get; set; }

    public virtual ReservaDeServicio? IdReservaServiciosRdssNavigation { get; set; }

    public virtual Servicio? IdServicioRddsNavigation { get; set; }
}
