using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BedAndDrinks.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace BedAndDrinks.Controllers
{
    [Authorize]
    public class HabitacionController : Controller
    {
        private readonly BedAndDrinkContext _context;

        public HabitacionController(BedAndDrinkContext context)
        {
            _context = context;
        }

        // GET: Habitaciones
        public async Task<IActionResult> Index()
        {
            var bedAndDrinkContext = _context.Habitacions.Include(h => h.IdHabitacionThNavigation);
            return View(await bedAndDrinkContext.ToListAsync());
        }

        // GET: Habitacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacions
                .Include(h => h.IdHabitacionThNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);

            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // GET: Habitacion/Create
        public IActionResult Create()
        {
            ViewData["IdHabitacionTh"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "Estado");
            return View();
        }

        // POST: Habitacion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHabitacion,Estado,IdHabitacionTh")] Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdHabitacionTh"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "Estado", habitacion.IdHabitacion);
            return View(habitacion);
        }

        // GET: Habitacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacions.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            ViewData["IdHabitacionTh"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "Estado", habitacion.IdHabitacion);
            return View(habitacion);
        }

        // POST: Habitacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHabitacion,Estado,IdHabitacionTh")] Habitacion habitacion)
        {
            if (id != habitacion.IdHabitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionExists(habitacion.IdHabitacion))
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

            ViewData["IdHabitacionTh"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "Estado", habitacion.IdHabitacion);
            return View(habitacion);
        }

        // GET: Habitacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacions
                .Include(h => h.IdHabitacionThNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);

            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // POST: Habitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitacion = await _context.Habitacions.FindAsync(id);
            _context.Habitacions.Remove(habitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionExists(int id)
        {
            return _context.Habitacions.Any(e => e.IdHabitacion == id);
        }
    }
}
