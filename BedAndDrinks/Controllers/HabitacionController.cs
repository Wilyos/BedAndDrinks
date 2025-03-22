using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BedAndDrinks.Models;
using FluentValidation;
using AspNetCoreGeneratedDocument;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


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
            var bedAndDrinkContext = _context.Habitacions.Include(h => h.IdHabitacionThNavigation); // Incluir la relación con TipoHabitacion
            return View(await bedAndDrinkContext.ToListAsync());
        }

        // GET: HomeController1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacions
                .Include(h => h.IdHabitacionThNavigation) // Incluir la relación con TipoHabitacion
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);

            if (habitacion == null) // Si no se encuentra la habitación
            {
                return NotFound(); // Devolver error 404
            }
                return View(habitacion);
        }

        // GET: HomeController1/Create
        public IActionResult Create()
        {
            ViewData["IdHabitacionTh"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion","Estado"); // Cargar los tipos de habitación
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHabitacion", "Estado")] Habitacion habitacion)
        {
            if (ModelState.IsValid) // Si el modelo es válido
            {
                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHabitacionTh"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "Estado", habitacion.IdHabitacionThNavigation);

            if (habitacion == null) // Si no se encuentra la habitación
            {
                return NotFound(); // Devolver error 404
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacions.FindAsync(id);
            if(habitacion == null)
            {
                return NotFound();
            }
            return View(habitacion);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("IdHabitacion", "Estado")] Habitacion habitacion)
        {
            if (ModelState.IsValid) // Si el modelo es válido
            {
                try
                {
                    _context.Update(habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionExists(habitacion.IdHabitacion)) // Si la habitación no existe
                    {
                        return NotFound(); // Devolver error 404
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirigir a la vista Index
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private bool HabitacionExists(int idHabitacion)
        {
            throw new NotImplementedException();
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, [Bind("IdHabitacion", "Estado")] Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Remove(habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionExists(habitacion.IdHabitacion)) // Si la habitación no existe
                    {
                        return NotFound(); // Devolver error 404
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            if(id == null)
            {
                return NotFound();
            }

            if (habitacion == null)
            {
                return NotFound();
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Details/5
        public async Task<IActionResult> DetailsConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var habitacion = await _context.Habitacions
                .Include(h => h.IdHabitacionThNavigation) // Incluir la relación con TipoHabitacion
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitacion == null) // Si no se encuentra la habitación
            {
                return NotFound(); // Devolver error 404
            }
            return View(habitacion);
        }
    }
}
