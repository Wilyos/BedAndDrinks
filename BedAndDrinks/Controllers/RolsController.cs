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
    public class RolsController : Controller
    {
        private readonly BedAndDrinkContext _context;

        public RolsController(BedAndDrinkContext context)
        {
            _context = context;
        }

        // GET: Rols
        public async Task<IActionResult> Index()
        {
            var bedAndDrinkContext = _context.Rols.Include(r => r.IdTipoRolRNavigation);
            return View(await bedAndDrinkContext.ToListAsync());
        }

        // GET: Rols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = await _context.Rols
                .Include(r => r.IdTipoRolRNavigation)
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // GET: Rols/Create
        public IActionResult Create()
        {
            ViewData["IdTipoRolR"] = new SelectList(_context.TipoRols, "IdTipoRol", "IdTipoRol");
            return View();
        }

        // POST: Rols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRol,NombreRol,IdTipoRolR,FechaCreacion,Estado")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Rols.AnyAsync(r => r.NombreRol == rol.NombreRol))
                {
                    ModelState.AddModelError("NombreRol", "El nombre del rol ya existe. Por favor, elija otro.");
                }
                else
                {
                    _context.Add(rol);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                  
            }
            ViewData["IdTipoRolR"] = new SelectList(_context.TipoRols, "IdTipoRol", "IdTipoRol", rol.IdTipoRolR);
            return View(rol);
        }

        // GET: Rols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = await _context.Rols.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            ViewData["IdTipoRolR"] = new SelectList(_context.TipoRols, "IdTipoRol", "IdTipoRol", rol.IdTipoRolR);
            return View(rol);
        }

        // POST: Rols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRol,NombreRol,IdTipoRolR,FechaCreacion,Estado")] Rol rol)
        {
            if (id != rol.IdRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolExists(rol.IdRol))
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
            ViewData["IdTipoRolR"] = new SelectList(_context.TipoRols, "IdTipoRol", "IdTipoRol", rol.IdTipoRolR);
            return View(rol);
        }

        // GET: Rols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = await _context.Rols
                .Include(r => r.IdTipoRolRNavigation)
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // POST: Rols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rol = await _context.Rols.FindAsync(id);
            if (rol != null)
            {
                _context.Rols.Remove(rol);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolExists(int id)
        {
            return _context.Rols.Any(e => e.IdRol == id);
        }
    }
}
