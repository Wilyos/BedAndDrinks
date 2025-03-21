using Microsoft.AspNetCore.Mvc;
using BedAndDrinks.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace BedAndDrinks.Controllers
{
    
    public class ReservaController : Controller
    {
        private readonly BedAndDrinkContext _context;

        public ReservaController(BedAndDrinkContext context)
        {
            _context = context;
        }

        // Método para listar las reservas
        public IActionResult Index()
        {
            var reservas = _context.Reservas.ToList();
            return View(reservas);
        }

        // Método para ver detalles de una reserva específica

        public IActionResult Details(int id)
        {
            var reserva = _context.Reservas.FirstOrDefault(r => r.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // Mostrar el formulario para crear una nueva reserva

        public IActionResult Create()
        {
            return View();
        }

        // Procesar el formulario de creación de reserva
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // Mostrar el formulario para editar una reserva
        public IActionResult Edit(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // Procesar la edición de la reserva
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Reserva reserva)
        {
            if (id != reserva.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(reserva);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }

        // Confirmar eliminación de una reserva
        public IActionResult Delete(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }

        // Procesar eliminación de la reserva
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
