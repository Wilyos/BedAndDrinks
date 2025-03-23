using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class Habitacion
{
    public int IdHabitacion { get; set; }
    public bool Estado { get; set; } = true;
    public int IdHabitacionTh { get; set; }
    public TipoHabitacion IdHabitacionThNavigation { get; set; }
    public virtual ICollection<ReservaHabitacion> ReservaHabitacions { get; set; } = new List<ReservaHabitacion>();

    public virtual ICollection<TipoHabitacion> TipoHabitacions { get; set; } = new List<TipoHabitacion>();
}
