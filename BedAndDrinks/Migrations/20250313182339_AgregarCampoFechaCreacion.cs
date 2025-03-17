using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BedAndDrinks.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoFechaCreacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    idHabitacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Habitaci__D9D53BE2EA163241", x => x.idHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "Huespedes",
                columns: table => new
                {
                    idHuesped = table.Column<int>(type: "int", nullable: false),
                    nombreHuesped = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    apellidoHuesped = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fechaNacimientoH = table.Column<DateOnly>(type: "date", nullable: true),
                    correoElectronicoH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    departamento = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ciudad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    telMovil = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Huespede__4B73CF9709A6CCDF", x => x.idHuesped);
                });

            migrationBuilder.CreateTable(
                name: "paquetes",
                columns: table => new
                {
                    idPaquete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__paquetes__646BA35FBD981CD5", x => x.idPaquete);
                });

            migrationBuilder.CreateTable(
                name: "permisos",
                columns: table => new
                {
                    idPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrePermiso = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__permisos__06A58486733566DA", x => x.idPermiso);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    idServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    categoria = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    costo = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    disponibilidad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    estado = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Servicio__CEB981191E26D17D", x => x.idServicio);
                });

            migrationBuilder.CreateTable(
                name: "TipoRol",
                columns: table => new
                {
                    idTipoRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoRol = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoRol__F81762AA87CF1075", x => x.idTipoRol);
                });

            migrationBuilder.CreateTable(
                name: "tipoHabitacion",
                columns: table => new
                {
                    idTipoHabitacion = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    capacidad = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    idHabitacionTH = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tipoHabi__64CD3F69840A4D5C", x => x.idTipoHabitacion);
                    table.ForeignKey(
                        name: "FK__tipoHabit__idHab__4BAC3F29",
                        column: x => x.idHabitacionTH,
                        principalTable: "Habitacion",
                        principalColumn: "idHabitacion");
                });

            migrationBuilder.CreateTable(
                name: "reservaDePaquetes",
                columns: table => new
                {
                    idReservaDePaquetes = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    idPaqueteRDP = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reservaD__0B271E1EE73DCCFE", x => x.idReservaDePaquetes);
                    table.ForeignKey(
                        name: "FK__reservaDe__idPaq__534D60F1",
                        column: x => x.idPaqueteRDP,
                        principalTable: "paquetes",
                        principalColumn: "idPaquete");
                });

            migrationBuilder.CreateTable(
                name: "paqueteServicios",
                columns: table => new
                {
                    idPaqueteservicios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaquetePS = table.Column<int>(type: "int", nullable: true),
                    idServicioPS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__paqueteS__6DBE89443DF4DAC1", x => x.idPaqueteservicios);
                    table.ForeignKey(
                        name: "FK__paqueteSe__idPaq__4F7CD00D",
                        column: x => x.idPaquetePS,
                        principalTable: "paquetes",
                        principalColumn: "idPaquete");
                    table.ForeignKey(
                        name: "FK__paqueteSe__idSer__5070F446",
                        column: x => x.idServicioPS,
                        principalTable: "Servicios",
                        principalColumn: "idServicio");
                });

            migrationBuilder.CreateTable(
                name: "permisosTipoRol",
                columns: table => new
                {
                    idPTR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPermisoPTR = table.Column<int>(type: "int", nullable: true),
                    idTipoRolPTR = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__permisos__3D065EF5A32D5E2E", x => x.idPTR);
                    table.ForeignKey(
                        name: "FK__permisosT__IdPer__45F365D3",
                        column: x => x.IdPermisoPTR,
                        principalTable: "permisos",
                        principalColumn: "idPermiso");
                    table.ForeignKey(
                        name: "FK__permisosT__idTip__44FF419A",
                        column: x => x.idTipoRolPTR,
                        principalTable: "TipoRol",
                        principalColumn: "idTipoRol");
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    idRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    idTipoRolR = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol__3C872F7693706329", x => x.idRol);
                    table.ForeignKey(
                        name: "FK__Rol__idTipoRolR__46E78A0C",
                        column: x => x.idTipoRolR,
                        principalTable: "TipoRol",
                        principalColumn: "idTipoRol");
                });

            migrationBuilder.CreateTable(
                name: "tipoHabitacionPaquetes",
                columns: table => new
                {
                    idTHP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTipoHabitacionTHP = table.Column<int>(type: "int", nullable: true),
                    idPaqueteTHP = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tipoHabi__020E80DF850417C7", x => x.idTHP);
                    table.ForeignKey(
                        name: "FK__tipoHabit__idPaq__5165187F",
                        column: x => x.idPaqueteTHP,
                        principalTable: "paquetes",
                        principalColumn: "idPaquete");
                    table.ForeignKey(
                        name: "FK__tipoHabit__idTip__52593CB8",
                        column: x => x.idTipoHabitacionTHP,
                        principalTable: "tipoHabitacion",
                        principalColumn: "idTipoHabitacion");
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    idReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    fechaCaducidad = table.Column<DateOnly>(type: "date", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    observacionesReserva = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    idReservaDePaquetesR = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reserva__94D104C8466E6303", x => x.idReserva);
                    table.ForeignKey(
                        name: "FK__Reserva__idReser__5441852A",
                        column: x => x.idReservaDePaquetesR,
                        principalTable: "reservaDePaquetes",
                        principalColumn: "idReservaDePaquetes");
                });

            migrationBuilder.CreateTable(
                name: "registros",
                columns: table => new
                {
                    idRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaLlegada = table.Column<DateOnly>(type: "date", nullable: true),
                    fechaSalida = table.Column<DateOnly>(type: "date", nullable: true),
                    valorTotal = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    idReservaReg = table.Column<int>(type: "int", nullable: true),
                    idHuespedReg = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__registro__62FC8F58683AED6C", x => x.idRegistro);
                    table.ForeignKey(
                        name: "FK__registros__idHue__5629CD9C",
                        column: x => x.idHuespedReg,
                        principalTable: "Huespedes",
                        principalColumn: "idHuesped");
                    table.ForeignKey(
                        name: "FK__registros__idRes__5535A963",
                        column: x => x.idReservaReg,
                        principalTable: "Reserva",
                        principalColumn: "idReserva");
                });

            migrationBuilder.CreateTable(
                name: "ReservaDeServicios",
                columns: table => new
                {
                    idReservaServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    observacionRS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    idReservaRS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReservaD__6DE53D0407D80932", x => x.idReservaServicio);
                    table.ForeignKey(
                        name: "FK__ReservaDe__idRes__4E88ABD4",
                        column: x => x.idReservaRS,
                        principalTable: "Reserva",
                        principalColumn: "idReserva");
                });

            migrationBuilder.CreateTable(
                name: "ReservaHabitacion",
                columns: table => new
                {
                    idReservaHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idHabitacionRH = table.Column<int>(type: "int", nullable: true),
                    idReservaRH = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReservaH__EBBB04C1D85D8567", x => x.idReservaHabitacion);
                    table.ForeignKey(
                        name: "FK__ReservaHa__idHab__4AB81AF0",
                        column: x => x.idHabitacionRH,
                        principalTable: "Habitacion",
                        principalColumn: "idHabitacion");
                    table.ForeignKey(
                        name: "FK__ReservaHa__idRes__49C3F6B7",
                        column: x => x.idReservaRH,
                        principalTable: "Reserva",
                        principalColumn: "idReserva");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    correoUsuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    estadoUsuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    observacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    contrasena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    idRolUsuario = table.Column<int>(type: "int", nullable: true),
                    idReservaU = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__645723A627A2FE78", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK__Usuario__idReser__48CFD27E",
                        column: x => x.idReservaU,
                        principalTable: "Reserva",
                        principalColumn: "idReserva");
                    table.ForeignKey(
                        name: "FK__Usuario__idRolUs__47DBAE45",
                        column: x => x.idRolUsuario,
                        principalTable: "Rol",
                        principalColumn: "idRol");
                });

            migrationBuilder.CreateTable(
                name: "reservaDSS",
                columns: table => new
                {
                    idreservaDDS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idReservaServiciosRDSS = table.Column<int>(type: "int", nullable: true),
                    idServicioRDDS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reservaD__165098225E11E3F7", x => x.idreservaDDS);
                    table.ForeignKey(
                        name: "FK__reservaDS__idRes__4CA06362",
                        column: x => x.idReservaServiciosRDSS,
                        principalTable: "ReservaDeServicios",
                        principalColumn: "idReservaServicio");
                    table.ForeignKey(
                        name: "FK__reservaDS__idSer__4D94879B",
                        column: x => x.idServicioRDDS,
                        principalTable: "Servicios",
                        principalColumn: "idServicio");
                });

            migrationBuilder.CreateIndex(
                name: "IX_paqueteServicios_idPaquetePS",
                table: "paqueteServicios",
                column: "idPaquetePS");

            migrationBuilder.CreateIndex(
                name: "IX_paqueteServicios_idServicioPS",
                table: "paqueteServicios",
                column: "idServicioPS");

            migrationBuilder.CreateIndex(
                name: "IX_permisosTipoRol_IdPermisoPTR",
                table: "permisosTipoRol",
                column: "IdPermisoPTR");

            migrationBuilder.CreateIndex(
                name: "IX_permisosTipoRol_idTipoRolPTR",
                table: "permisosTipoRol",
                column: "idTipoRolPTR");

            migrationBuilder.CreateIndex(
                name: "IX_registros_idHuespedReg",
                table: "registros",
                column: "idHuespedReg");

            migrationBuilder.CreateIndex(
                name: "IX_registros_idReservaReg",
                table: "registros",
                column: "idReservaReg");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_idReservaDePaquetesR",
                table: "Reserva",
                column: "idReservaDePaquetesR");

            migrationBuilder.CreateIndex(
                name: "IX_reservaDePaquetes_idPaqueteRDP",
                table: "reservaDePaquetes",
                column: "idPaqueteRDP");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaDeServicios_idReservaRS",
                table: "ReservaDeServicios",
                column: "idReservaRS");

            migrationBuilder.CreateIndex(
                name: "IX_reservaDSS_idReservaServiciosRDSS",
                table: "reservaDSS",
                column: "idReservaServiciosRDSS");

            migrationBuilder.CreateIndex(
                name: "IX_reservaDSS_idServicioRDDS",
                table: "reservaDSS",
                column: "idServicioRDDS");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_idHabitacionRH",
                table: "ReservaHabitacion",
                column: "idHabitacionRH");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_idReservaRH",
                table: "ReservaHabitacion",
                column: "idReservaRH");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_idTipoRolR",
                table: "Rol",
                column: "idTipoRolR");

            migrationBuilder.CreateIndex(
                name: "IX_tipoHabitacion_idHabitacionTH",
                table: "tipoHabitacion",
                column: "idHabitacionTH");

            migrationBuilder.CreateIndex(
                name: "IX_tipoHabitacionPaquetes_idPaqueteTHP",
                table: "tipoHabitacionPaquetes",
                column: "idPaqueteTHP");

            migrationBuilder.CreateIndex(
                name: "IX_tipoHabitacionPaquetes_idTipoHabitacionTHP",
                table: "tipoHabitacionPaquetes",
                column: "idTipoHabitacionTHP");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idReservaU",
                table: "Usuario",
                column: "idReservaU");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idRolUsuario",
                table: "Usuario",
                column: "idRolUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paqueteServicios");

            migrationBuilder.DropTable(
                name: "permisosTipoRol");

            migrationBuilder.DropTable(
                name: "registros");

            migrationBuilder.DropTable(
                name: "reservaDSS");

            migrationBuilder.DropTable(
                name: "ReservaHabitacion");

            migrationBuilder.DropTable(
                name: "tipoHabitacionPaquetes");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "permisos");

            migrationBuilder.DropTable(
                name: "Huespedes");

            migrationBuilder.DropTable(
                name: "ReservaDeServicios");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "tipoHabitacion");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "TipoRol");

            migrationBuilder.DropTable(
                name: "reservaDePaquetes");

            migrationBuilder.DropTable(
                name: "paquetes");
        }
    }
}
