using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class Paquete
{
    public int IdPaquete { get; set; }

    public virtual ICollection<PaqueteServicio> PaqueteServicios { get; set; } = new List<PaqueteServicio>();

    public virtual ICollection<ReservaDePaquete> ReservaDePaquetes { get; set; } = new List<ReservaDePaquete>();

    public virtual ICollection<TipoHabitacionPaquete> TipoHabitacionPaquetes { get; set; } = new List<TipoHabitacionPaquete>();
}
