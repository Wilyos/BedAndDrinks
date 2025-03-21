using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public DateTime? Fecha { get; set; }

    public DateOnly? FechaCaducidad { get; set; }

    public string? Estado { get; set; }

    public string? ObservacionesReserva { get; set; }

    public int? IdReservaDePaquetesR { get; set; }

    public virtual ReservaDePaquete? IdReservaDePaquetesRNavigation { get; set; }

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();

    public virtual ICollection<ReservaDeServicio> ReservaDeServicios { get; set; } = [];

    public virtual ICollection<ReservaHabitacion> ReservaHabitacions { get; set; } = [];

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
