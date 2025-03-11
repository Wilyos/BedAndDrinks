using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class PermisosTipoRol
{
    public int IdPtr { get; set; }

    public int? IdPermisoPtr { get; set; }

    public int? IdTipoRolPtr { get; set; }

    public virtual Permiso? IdPermisoPtrNavigation { get; set; }

    public virtual TipoRol? IdTipoRolPtrNavigation { get; set; }
}
