using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class TipoHabitacionPaquete
{
    public int IdThp { get; set; }

    public int? IdTipoHabitacionThp { get; set; }

    public int? IdPaqueteThp { get; set; }

    public virtual Paquete? IdPaqueteThpNavigation { get; set; }

    public virtual TipoHabitacion? IdTipoHabitacionThpNavigation { get; set; }
}
