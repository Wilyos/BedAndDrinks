using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? CorreoUsuario { get; set; }

    public string? EstadoUsuario { get; set; }

    public string? Observacion { get; set; }

    public string? Contrasena { get; set; }

    public int? IdRolUsuario { get; set; }

    public int? IdReservaU { get; set; }

    public virtual Reserva? IdReservaUNavigation { get; set; }

    public virtual Rol? IdRolUsuarioNavigation { get; set; }
}
