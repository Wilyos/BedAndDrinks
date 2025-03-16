using FluentValidation;
using BedAndDrinks.Models;

namespace BedAndDrinks.Models
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        private readonly BedAndDrinkContext _context;

        public UsuarioValidator(BedAndDrinkContext context) // Constructor
        {
            _context = context; // Inicializa el contexto

            if(_context == null) // Verifica si el contexto es nulo
            {
                throw new System.ArgumentNullException(nameof(context)); // Lanza una excepción
                
            }

            RuleFor(x => x.IdUsuario)
                .NotEmpty().WithMessage("El id del usuario es requerido")
                .Must(UniqueIdUsuario).WithMessage("El id del usuario ya existe");

            RuleFor(x => x.NombreUsuario) // Reglas de validación
                .NotEmpty().WithMessage("El nombre es requerido")
                .Must(UniqueName).WithMessage("El nombre de usuario ya existe");

            RuleFor(x => x.CorreoUsuario)
                .NotEmpty().WithMessage("El correo es requerido")
                .EmailAddress().WithMessage("El correo no es válido")
                .Must(UniqueEmail).WithMessage("El correo ya existe");

            RuleFor(x => x.Contrasena)
                .NotEmpty().WithMessage("La contraseña es requerida")
                .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres")
                .Matches("[A-Z]").WithMessage("La contraseña debe tener al menos una letra mayúscula")
                .Matches("[a-z]").WithMessage("La contraseña debe tener al menos una letra minúscula")
                .Matches("[0-9]").WithMessage("La contraseña debe tener al menos un número");

            RuleFor(x => x.IdRolUsuario) 
                .NotEmpty().WithMessage("El rol es requerido")
                .Must(x => _context.Rols.Any(y => y.IdRol == x)).WithMessage("El rol no existe");

           /* RuleFor(x => x.IdReservaU)
                .NotEmpty().WithMessage("La reserva es requerida")
                .Must(x => _context.Reservas.Any(y => y.IdReserva == x)).WithMessage("La reserva no existe"); */

            /*RuleFor(x => x.EstadoUsuario)
                .NotEmpty().WithMessage("El estado usuario es requerido")
                .Must(x => x == "Activo" || x == "Inactivo").WithMessage("El estado usuario debe ser Activo o Inactivo"); */

            RuleFor(x => x.Observacion)
                .MaximumLength(200).WithMessage("La observación no puede tener más de 200 caracteres");
        }

        private bool UniqueIdUsuario(int id)
        {
            return _context.Usuarios.All(x => x.IdUsuario != id); // Verifica que el id de usuario no exista
        }

        private bool UniqueName(string? name)
        {
            return _context.Usuarios.All(x => x.NombreUsuario != name); // Verifica que el nombre de usuario no exista
        }

        private bool UniqueEmail(string email)
        {
            return _context.Usuarios.All(x => x.CorreoUsuario != email); // Verifica que el correo no exista
        }
    }
}
