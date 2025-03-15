using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BedAndDrinks.Models;

public partial class BedAndDrinkContext : DbContext
{
    public BedAndDrinkContext()
    {
    }

    public BedAndDrinkContext(DbContextOptions<BedAndDrinkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<Huespede> Huespedes { get; set; }

    public virtual DbSet<Paquete> Paquetes { get; set; }

    public virtual DbSet<PaqueteServicio> PaqueteServicios { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PermisosTipoRol> PermisosTipoRols { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<ReservaDePaquete> ReservaDePaquetes { get; set; }

    public virtual DbSet<ReservaDeServicio> ReservaDeServicios { get; set; }

    public virtual DbSet<ReservaDss> ReservaDsses { get; set; }

    public virtual DbSet<ReservaHabitacion> ReservaHabitacions { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; }

    public virtual DbSet<TipoHabitacionPaquete> TipoHabitacionPaquetes { get; set; }

    public virtual DbSet<TipoRol> TipoRols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-K0A8JF9\\SQLEXPRESS; database=bedAndDrink; integrated security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__D9D53BE2EA163241");

            entity.ToTable("Habitacion");

            entity.Property(e => e.IdHabitacion)
                .ValueGeneratedNever()
                .HasColumnName("idHabitacion");
        });

        modelBuilder.Entity<Huespede>(entity =>
        {
            entity.HasKey(e => e.IdHuesped).HasName("PK__Huespede__4B73CF9709A6CCDF");

            entity.Property(e => e.IdHuesped)
                .ValueGeneratedNever()
                .HasColumnName("idHuesped");
            entity.Property(e => e.ApellidoHuesped)
                .HasMaxLength(255)
                .HasColumnName("apellidoHuesped");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(255)
                .HasColumnName("ciudad");
            entity.Property(e => e.CorreoElectronicoH)
                .HasMaxLength(255)
                .HasColumnName("correoElectronicoH");
            entity.Property(e => e.Departamento)
                .HasMaxLength(255)
                .HasColumnName("departamento");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimientoH).HasColumnName("fechaNacimientoH");
            entity.Property(e => e.NombreHuesped)
                .HasMaxLength(255)
                .HasColumnName("nombreHuesped");
            entity.Property(e => e.TelMovil)
                .HasMaxLength(255)
                .HasColumnName("telMovil");
        });

        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.HasKey(e => e.IdPaquete).HasName("PK__paquetes__646BA35FBD981CD5");

            entity.ToTable("paquetes");

            entity.Property(e => e.IdPaquete).HasColumnName("idPaquete");
        });

        modelBuilder.Entity<PaqueteServicio>(entity =>
        {
            entity.HasKey(e => e.IdPaqueteservicios).HasName("PK__paqueteS__6DBE89443DF4DAC1");

            entity.ToTable("paqueteServicios");

            entity.Property(e => e.IdPaqueteservicios).HasColumnName("idPaqueteservicios");
            entity.Property(e => e.IdPaquetePs).HasColumnName("idPaquetePS");
            entity.Property(e => e.IdServicioPs).HasColumnName("idServicioPS");

            entity.HasOne(d => d.IdPaquetePsNavigation).WithMany(p => p.PaqueteServicios)
                .HasForeignKey(d => d.IdPaquetePs)
                .HasConstraintName("FK__paqueteSe__idPaq__4F7CD00D");

            entity.HasOne(d => d.IdServicioPsNavigation).WithMany(p => p.PaqueteServicios)
                .HasForeignKey(d => d.IdServicioPs)
                .HasConstraintName("FK__paqueteSe__idSer__5070F446");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__permisos__06A58486733566DA");

            entity.ToTable("permisos");

            entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(255)
                .HasColumnName("nombrePermiso");
        });

        modelBuilder.Entity<PermisosTipoRol>(entity =>
        {
            entity.HasKey(e => e.IdPtr).HasName("PK__permisos__3D065EF5A32D5E2E");

            entity.ToTable("permisosTipoRol");

            entity.Property(e => e.IdPtr).HasColumnName("idPTR");
            entity.Property(e => e.IdPermisoPtr).HasColumnName("IdPermisoPTR");
            entity.Property(e => e.IdTipoRolPtr).HasColumnName("idTipoRolPTR");

            entity.HasOne(d => d.IdPermisoPtrNavigation).WithMany(p => p.PermisosTipoRols)
                .HasForeignKey(d => d.IdPermisoPtr)
                .HasConstraintName("FK__permisosT__IdPer__45F365D3");

            entity.HasOne(d => d.IdTipoRolPtrNavigation).WithMany(p => p.PermisosTipoRols)
                .HasForeignKey(d => d.IdTipoRolPtr)
                .HasConstraintName("FK__permisosT__idTip__44FF419A");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("PK__registro__62FC8F58683AED6C");

            entity.ToTable("registros");

            entity.Property(e => e.IdRegistro).HasColumnName("idRegistro");
            entity.Property(e => e.FechaLlegada).HasColumnName("fechaLlegada");
            entity.Property(e => e.FechaSalida).HasColumnName("fechaSalida");
            entity.Property(e => e.IdHuespedReg).HasColumnName("idHuespedReg");
            entity.Property(e => e.IdReservaReg).HasColumnName("idReservaReg");
            entity.Property(e => e.ValorTotal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("valorTotal");

            entity.HasOne(d => d.IdHuespedRegNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdHuespedReg)
                .HasConstraintName("FK__registros__idHue__5629CD9C");

            entity.HasOne(d => d.IdReservaRegNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdReservaReg)
                .HasConstraintName("FK__registros__idRes__5535A963");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reserva__94D104C8466E6303");

            entity.ToTable("Reserva");

            entity.Property(e => e.IdReserva).HasColumnName("idReserva");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaCaducidad).HasColumnName("fechaCaducidad");
            entity.Property(e => e.IdReservaDePaquetesR).HasColumnName("idReservaDePaquetesR");
            entity.Property(e => e.ObservacionesReserva)
                .HasMaxLength(255)
                .HasColumnName("observacionesReserva");

            entity.HasOne(d => d.IdReservaDePaquetesRNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdReservaDePaquetesR)
                .HasConstraintName("FK__Reserva__idReser__5441852A");
        });

        modelBuilder.Entity<ReservaDePaquete>(entity =>
        {
            entity.HasKey(e => e.IdReservaDePaquetes).HasName("PK__reservaD__0B271E1EE73DCCFE");

            entity.ToTable("reservaDePaquetes");

            entity.Property(e => e.IdReservaDePaquetes)
                .ValueGeneratedNever()
                .HasColumnName("idReservaDePaquetes");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdPaqueteRdp).HasColumnName("idPaqueteRDP");

            entity.HasOne(d => d.IdPaqueteRdpNavigation).WithMany(p => p.ReservaDePaquetes)
                .HasForeignKey(d => d.IdPaqueteRdp)
                .HasConstraintName("FK__reservaDe__idPaq__534D60F1");
        });

        modelBuilder.Entity<ReservaDeServicio>(entity =>
        {
            entity.HasKey(e => e.IdReservaServicio).HasName("PK__ReservaD__6DE53D0407D80932");

            entity.Property(e => e.IdReservaServicio).HasColumnName("idReservaServicio");
            entity.Property(e => e.IdReservaRs).HasColumnName("idReservaRS");
            entity.Property(e => e.ObservacionRs)
                .HasMaxLength(255)
                .HasColumnName("observacionRS");

            entity.HasOne(d => d.IdReservaRsNavigation).WithMany(p => p.ReservaDeServicios)
                .HasForeignKey(d => d.IdReservaRs)
                .HasConstraintName("FK__ReservaDe__idRes__4E88ABD4");
        });

        modelBuilder.Entity<ReservaDss>(entity =>
        {
            entity.HasKey(e => e.IdreservaDds).HasName("PK__reservaD__165098225E11E3F7");

            entity.ToTable("reservaDSS");

            entity.Property(e => e.IdreservaDds).HasColumnName("idreservaDDS");
            entity.Property(e => e.IdReservaServiciosRdss).HasColumnName("idReservaServiciosRDSS");
            entity.Property(e => e.IdServicioRdds).HasColumnName("idServicioRDDS");

            entity.HasOne(d => d.IdReservaServiciosRdssNavigation).WithMany(p => p.ReservaDsses)
                .HasForeignKey(d => d.IdReservaServiciosRdss)
                .HasConstraintName("FK__reservaDS__idRes__4CA06362");

            entity.HasOne(d => d.IdServicioRddsNavigation).WithMany(p => p.ReservaDsses)
                .HasForeignKey(d => d.IdServicioRdds)
                .HasConstraintName("FK__reservaDS__idSer__4D94879B");
        });

        modelBuilder.Entity<ReservaHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdReservaHabitacion).HasName("PK__ReservaH__EBBB04C1D85D8567");

            entity.ToTable("ReservaHabitacion");

            entity.Property(e => e.IdReservaHabitacion).HasColumnName("idReservaHabitacion");
            entity.Property(e => e.IdHabitacionRh).HasColumnName("idHabitacionRH");
            entity.Property(e => e.IdReservaRh).HasColumnName("idReservaRH");

            entity.HasOne(d => d.IdHabitacionRhNavigation).WithMany(p => p.ReservaHabitacions)
                .HasForeignKey(d => d.IdHabitacionRh)
                .HasConstraintName("FK__ReservaHa__idHab__4AB81AF0");

            entity.HasOne(d => d.IdReservaRhNavigation).WithMany(p => p.ReservaHabitacions)
                .HasForeignKey(d => d.IdReservaRh)
                .HasConstraintName("FK__ReservaHa__idRes__49C3F6B7");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F7693706329");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IdTipoRolR).HasColumnName("idTipoRolR");
            entity.Property(e => e.NombreRol).HasMaxLength(255);
            entity.HasOne(d => d.IdTipoRolRNavigation).WithMany(p => p.Rols)
                .HasForeignKey(d => d.IdTipoRolR)
                .HasConstraintName("FK__Rol__idTipoRolR__46E78A0C");
            entity.Property(e => e.FechaCreacion).HasColumnName("fechaCreacion");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__CEB981191E26D17D");

            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.Categoria)
                .HasMaxLength(255)
                .HasColumnName("categoria");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Disponibilidad)
                .HasMaxLength(255)
                .HasColumnName("disponibilidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoHabitacion).HasName("PK__tipoHabi__64CD3F69840A4D5C");

            entity.ToTable("tipoHabitacion");

            entity.Property(e => e.IdTipoHabitacion)
                .ValueGeneratedNever()
                .HasColumnName("idTipoHabitacion");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdHabitacionTh).HasColumnName("idHabitacionTH");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdHabitacionThNavigation).WithMany(p => p.TipoHabitacions)
                .HasForeignKey(d => d.IdHabitacionTh)
                .HasConstraintName("FK__tipoHabit__idHab__4BAC3F29");
        });

        modelBuilder.Entity<TipoHabitacionPaquete>(entity =>
        {
            entity.HasKey(e => e.IdThp).HasName("PK__tipoHabi__020E80DF850417C7");

            entity.ToTable("tipoHabitacionPaquetes");

            entity.Property(e => e.IdThp).HasColumnName("idTHP");
            entity.Property(e => e.IdPaqueteThp).HasColumnName("idPaqueteTHP");
            entity.Property(e => e.IdTipoHabitacionThp).HasColumnName("idTipoHabitacionTHP");

            entity.HasOne(d => d.IdPaqueteThpNavigation).WithMany(p => p.TipoHabitacionPaquetes)
                .HasForeignKey(d => d.IdPaqueteThp)
                .HasConstraintName("FK__tipoHabit__idPaq__5165187F");

            entity.HasOne(d => d.IdTipoHabitacionThpNavigation).WithMany(p => p.TipoHabitacionPaquetes)
                .HasForeignKey(d => d.IdTipoHabitacionThp)
                .HasConstraintName("FK__tipoHabit__idTip__52593CB8");
        });

        modelBuilder.Entity<TipoRol>(entity =>
        {
            entity.HasKey(e => e.IdTipoRol).HasName("PK__TipoRol__F81762AA87CF1075");

            entity.ToTable("TipoRol");

            entity.Property(e => e.IdTipoRol).HasColumnName("idTipoRol");
            entity.Property(e => e.NombreTipoRol).HasMaxLength(255);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A627A2FE78");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("idUsuario");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .HasColumnName("contrasena");
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(255)
                .HasColumnName("correoUsuario");
            entity.Property(e => e.EstadoUsuario)
                .HasMaxLength(255)
                .HasColumnName("estadoUsuario");
            entity.Property(e => e.IdReservaU).HasColumnName("idReservaU");
            entity.Property(e => e.IdRolUsuario).HasColumnName("idRolUsuario");
            entity.Property(e => e.NombreUsuario).HasMaxLength(255);
            entity.Property(e => e.Observacion)
                .HasMaxLength(255)
                .HasColumnName("observacion");

            entity.HasOne(d => d.IdReservaUNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdReservaU)
                .HasConstraintName("FK__Usuario__idReser__48CFD27E");

            entity.HasOne(d => d.IdRolUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRolUsuario)
                .HasConstraintName("FK__Usuario__idRolUs__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
