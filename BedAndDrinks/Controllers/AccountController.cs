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

            // Buscar usuario en la base de datos
            var usuario = _context.Usuarios.FirstOrDefault(u => u.CorreoUsuario == model.CorreoUsuario && u.Contrasena == model.Contrasena);

            if (usuario == null)
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
                return View(model);
            }

            // Crear Claims con el ID del Rol
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.NombreUsuario),
            new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
            new Claim("RolId", usuario.IdRolUsuario.ToString()) // Guardar ID del Rol
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            
            {
                IsPersistent = false
            };

            // Iniciar sesión
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index", "Home");
        }

        // Cerrar sesión
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Cierra la sesión del usuario
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Elimina la cookie de autenticación
            Response.Cookies.Delete(".AspNetCore.Cookies");

            return RedirectToAction("Login", "Account");
        }

        // Página de acceso denegado
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
    
}
