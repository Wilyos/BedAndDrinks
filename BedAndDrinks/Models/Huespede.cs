using System;
using System.Collections.Generic;

namespace BedAndDrinks.Models;

public partial class Huespede
{
    public int IdHuesped { get; set; }

    public string? NombreHuesped { get; set; }

    public string? ApellidoHuesped { get; set; }

    public DateOnly? FechaNacimientoH { get; set; }

    public string? CorreoElectronicoH { get; set; }

    public string? Departamento { get; set; }

    public string? Ciudad { get; set; }

    public string? Direccion { get; set; }

    public string? TelMovil { get; set; }

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
}
