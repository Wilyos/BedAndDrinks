using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BedAndDrinks.Models;

namespace BedAndDrinks.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly BedAndDrinkContext _context;

        public UsuariosController(BedAndDrinkContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var bedAndDrinkContext = _context.Usuarios.Include(u => u.IdReservaUNavigation).Include(u => u.IdRolUsuarioNavigation);
            return View(await bedAndDrinkContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdReservaUNavigation)
                .Include(u => u.IdRolUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["IdReservaU"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva");
            ViewData["IdRolUsuario"] = new SelectList(_context.Rols, "IdRol", "IdRol");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,NombreUsuario,CorreoUsuario,EstadoUsuario,Observacion,Contrasena,IdRolUsuario,IdReservaU")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if(Nom)
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdReservaU"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", usuario.IdReservaU);
            ViewData["IdRolUsuario"] = new SelectList(_context.Rols, "IdRol", "IdRol", usuario.IdRolUsuario);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["IdReservaU"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", usuario.IdReservaU);
            ViewData["IdRolUsuario"] = new SelectList(_context.Rols, "IdRol", "IdRol", usuario.IdRolUsuario);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,NombreUsuario,CorreoUsuario,EstadoUsuario,Observacion,Contrasena,IdRolUsuario,IdReservaU")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdReservaU"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", usuario.IdReservaU);
            ViewData["IdRolUsuario"] = new SelectList(_context.Rols, "IdRol", "IdRol", usuario.IdRolUsuario);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdReservaUNavigation)
                .Include(u => u.IdRolUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
