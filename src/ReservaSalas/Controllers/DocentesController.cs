
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaSalas.Data;
using ReservaSalas.Models;

namespace ReservaSalas.Controllers
{
    public class DocentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listar todos os docentes
        public async Task<IActionResult> Index()
        {
            var docentes = await _context.Docentes.ToListAsync();

            return View(docentes);
        }


        // Mostrar formulário para adicionar um docente
        public IActionResult Create()
        {
            return View();
        }

        // Receber e guardar os dados do novo docente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Docente docente)
        {
            if (ModelState.IsValid)
            {
                _context.Docentes.Add(docente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(docente);
        }

        // Mostrar formulário de edição
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docente = await _context.Docentes.FindAsync(id);

            if (docente == null)
            {
                return NotFound();
            }

            return View(docente);
        }

        // Guardar alterações do docente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Docente docente)
        {
            if (id != docente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(docente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(docente);
        }


        // Mostrar página de confirmação da eliminação
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docente = await _context.Docentes
                .FirstOrDefaultAsync(d => d.Id == id);

            if (docente == null)
            {
                return NotFound();
            }

            return View(docente);
        }

        // Eliminar docente da base de dados
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docente = await _context.Docentes.FindAsync(id);

            if (docente != null)
            {
                _context.Docentes.Remove(docente);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}