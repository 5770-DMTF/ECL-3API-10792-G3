
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
            docente.Nome = docente.Nome?.Trim() ?? string.Empty;
            docente.Email = docente.Email?.Trim() ?? string.Empty;
            docente.Area = docente.Area?.Trim() ?? string.Empty;

            bool emailExiste = await _context.Docentes
                .AnyAsync(d => d.Email.ToLower() == docente.Email.ToLower());

            if (emailExiste)
            {
                ModelState.AddModelError(
                    "Email",
                    "Já existe um docente com este email."
                );
            }

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

            docente.Nome = docente.Nome?.Trim() ?? string.Empty;
            docente.Email = docente.Email?.Trim() ?? string.Empty;
            docente.Area = docente.Area?.Trim() ?? string.Empty;

            bool emailExiste = await _context.Docentes
                .AnyAsync(d => d.Email.ToLower() == docente.Email.ToLower()
                            && d.Id != docente.Id);

            if (emailExiste)
            {
                ModelState.AddModelError(
                    "Email",
                    "Já existe outro docente com este email."
                );
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

            if (docente == null)
            {
                return NotFound();
            }

            bool temReservas = await _context.Reservas
                .AnyAsync(r => r.DocenteId == id);

            if (temReservas)
            {
                TempData["Erro"] = "Não é possível eliminar este docente porque existem reservas associadas.";
                return RedirectToAction(nameof(Index));
            }

            _context.Docentes.Remove(docente);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}