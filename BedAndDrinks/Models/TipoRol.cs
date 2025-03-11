using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class TipoRol
{
    public int IdTipoRol { get; set; }

    public string? NombreTipoRol { get; set; }

    public virtual ICollection<PermisosTipoRol> PermisosTipoRols { get; set; } = new List<PermisosTipoRol>();

    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();
}
