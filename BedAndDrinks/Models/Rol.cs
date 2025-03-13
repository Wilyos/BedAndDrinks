using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    public int? IdTipoRolR { get; set; }

    public DateOnly FechaCreacion { get; set; }

    public Boolean Estado { get; set; } = true;

    public virtual TipoRol? IdTipoRolRNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
