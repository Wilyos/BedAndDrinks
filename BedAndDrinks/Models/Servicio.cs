using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Categoria { get; set; }

    public decimal? Costo { get; set; }

    public string? Disponibilidad { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<PaqueteServicio> PaqueteServicios { get; set; } = new List<PaqueteServicio>();

    public virtual ICollection<ReservaDss> ReservaDsses { get; set; } = new List<ReservaDss>();
}
