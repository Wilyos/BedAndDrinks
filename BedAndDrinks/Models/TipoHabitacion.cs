using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class TipoHabitacion
{
    public int IdTipoHabitacion { get; set; }

    public string? Nombre { get; set; }

    public int? Capacidad { get; set; }

    public decimal? Precio { get; set; }

    public string? Descripcion { get; set; }

    public int? IdHabitacionTh { get; set; }

    public virtual Habitacion? IdHabitacionThNavigation { get; set; }

    public virtual ICollection<TipoHabitacionPaquete> TipoHabitacionPaquetes { get; set; } = new List<TipoHabitacionPaquete>();
}
