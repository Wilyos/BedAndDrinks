using BedAndDrinks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;


namespace BedAndDrinks.Controllers
{
    public class AccountController : Controller
    {
        private readonly BedAndDrinkContext _context; // Tu DbContext


        public AccountController(BedAndDrinkContext context)
        {
            _context = context;
        }
        // Mostrar vista de Login
        public IActionResult Login()
        {
            return View();
        }

        // Procesar Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = _context.Usuarios
                .Include(u => u.IdRolUsuarioNavigation) // Cargar el Rol
                .FirstOrDefault(u => u.CorreoUsuario == model.CorreoUsuario && u.Contrasena == model.Contrasena);

            if (usuario == null)
            {
                ModelState.AddModelError("Contrasena", "Usuario o contraseña incorrectos.");
                return View(model);
            }

            // Obtener los permisos del usuario desde la relación de su rol
            var permisos = _context.PermisosTipoRols
                .Where(ptr => ptr.IdTipoRolPtr == usuario.IdRolUsuario)
                .Select(ptr => ptr.IdPermisoPtrNavigation.NombrePermiso) // Traer solo los nombres de los permisos
                .ToList();

            // Crear Claims
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, usuario.NombreUsuario),
        new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString())
    };

            // Agregar los permisos como Claims
            foreach (var permiso in permisos)
            {
                claims.Add(new Claim("Permiso", permiso));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = false };

            // Iniciar sesión
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");
        }
    }
    
}
