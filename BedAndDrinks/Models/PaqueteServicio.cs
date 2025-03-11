using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class PaqueteServicio
{
    public int IdPaqueteservicios { get; set; }

    public int? IdPaquetePs { get; set; }

    public int? IdServicioPs { get; set; }

    public virtual Paquete? IdPaquetePsNavigation { get; set; }

    public virtual Servicio? IdServicioPsNavigation { get; set; }
}
