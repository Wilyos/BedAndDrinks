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
    public class TipoRolesController : Controller
    {
        private readonly BedAndDrinkContext _context;

        public TipoRolesController(BedAndDrinkContext context)
        {
            _context = context;
        }

        // GET: TipoRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoRols.ToListAsync());
        }

        // GET: TipoRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRol = await _context.TipoRols
                .FirstOrDefaultAsync(m => m.IdTipoRol == id);
            if (tipoRol == null)
            {
                return NotFound();
            }

            return View(tipoRol);
        }

        // GET: TipoRoles/Create
        public IActionResult Create()
        {
            var permisos = _context.Permisos.ToList(); // Para evitar el error
            Console.WriteLine($"[GET] Permisos cargados: {permisos.Count}");

            ViewBag.Permisos = permisos;


            return View();
        }

        // POST: TipoRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoRol,NombreTipoRol")] TipoRol tipoRol, int[] seleccionadosPermisos)
        {
            Console.WriteLine("[POST] Método Create ejecutado");
            var permisos = await _context.Permisos.ToListAsync();
            ViewBag.Permisos = permisos;
            Console.WriteLine($"[POST] Permisos recargados: {permisos.Count}");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("[POST] ModelState no es válido");
                return View(tipoRol);
            }

                _context.Add(tipoRol);
                await _context.SaveChangesAsync();

            Console.WriteLine($"[POST] TipoRol guardado con ID: {tipoRol.IdTipoRol}");

            if (seleccionadosPermisos != null && seleccionadosPermisos.Length > 0)
            {
                foreach (int idPermiso in seleccionadosPermisos)
                {

                    _context.PermisosTipoRols.Add(new PermisosTipoRol
                    {
                        IdTipoRolPtr = tipoRol.IdTipoRol,
                        IdPermisoPtr = Permiso.ReferenceEquals(_context.Permisos.Find(idPermiso), null) ? 0 : idPermiso
                    });
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Console.WriteLine("[POST] No se seleccionaron permisos");
            }
            return View(tipoRol);
        }

        // GET: TipoRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRol = await _context.TipoRols.FindAsync(id);
            if (tipoRol == null)
            {
                return NotFound();
            }
            return View(tipoRol);
        }

        // POST: TipoRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoRol,NombreTipoRol")] TipoRol tipoRol)
        {
            if (id != tipoRol.IdTipoRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoRol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoRolExists(tipoRol.IdTipoRol))
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
            return View(tipoRol);
        }

        // GET: TipoRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRol = await _context.TipoRols
                .FirstOrDefaultAsync(m => m.IdTipoRol == id);
            if (tipoRol == null)
            {
                return NotFound();
            }

            return View(tipoRol);
        }

        // POST: TipoRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoRol = await _context.TipoRols.FindAsync(id);
            if (tipoRol != null)
            {
                _context.TipoRols.Remove(tipoRol);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoRolExists(int id)
        {
            return _context.TipoRols.Any(e => e.IdTipoRol == id);
        }
    }
}
