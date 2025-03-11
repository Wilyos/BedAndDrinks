using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string? NombrePermiso { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<PermisosTipoRol> PermisosTipoRols { get; set; } = new List<PermisosTipoRol>();
}
