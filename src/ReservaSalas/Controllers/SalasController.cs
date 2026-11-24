
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaSalas.Data;
using ReservaSalas.Models;

namespace ReservaSalas.Controllers
{
    public class SalasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listar todas as salas
        public async Task<IActionResult> Index()
        {
            var salas = await _context.Salas.ToListAsync();

            return View(salas);
        }


        // Mostrar formulário para adicionar uma sala
        public IActionResult Create()
        {
            return View();
        }

        // Receber e guardar os dados da nova sala
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sala sala)
        {
            sala.Codigo = sala.Codigo?.Trim() ?? string.Empty;
            sala.Tipo = sala.Tipo?.Trim() ?? string.Empty;

            bool codigoExiste = await _context.Salas
                .AnyAsync(s => s.Codigo.ToLower() == sala.Codigo.ToLower());

            if (codigoExiste)
            {
                ModelState.AddModelError(
                    "Codigo",
                    "Já existe uma sala com este código."
                );
            }

            if (ModelState.IsValid)
            {
                _context.Salas.Add(sala);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(sala);
        }

        // Mostrar formulário de edição
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas.FindAsync(id);

            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // Guardar alterações da sala
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sala sala)
        {
            if (id != sala.Id)
            {
                return NotFound();
            }

            sala.Codigo = sala.Codigo?.Trim() ?? string.Empty;
            sala.Tipo = sala.Tipo?.Trim() ?? string.Empty;

            bool codigoExiste = await _context.Salas
                .AnyAsync(s => s.Codigo.ToLower() == sala.Codigo.ToLower()
                            && s.Id != sala.Id);

            if (codigoExiste)
            {
                ModelState.AddModelError(
                    "Codigo",
                    "Já existe outra sala com este código."
                );
            }

            if (ModelState.IsValid)
            {
                _context.Update(sala);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(sala);
        }


        // Mostrar página de confirmação da eliminação
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // Eliminar sala da base de dados        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sala = await _context.Salas.FindAsync(id);

            if (sala == null)
            {
                return NotFound();
            }

            bool temReservas = await _context.Reservas
                .AnyAsync(r => r.SalaId == id);

            if (temReservas)
            {
                TempData["Erro"] = "Não é possível eliminar esta sala porque existem reservas associadas.";
                return RedirectToAction(nameof(Index));
            }

            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}