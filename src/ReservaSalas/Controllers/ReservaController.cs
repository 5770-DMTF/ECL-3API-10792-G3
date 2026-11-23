using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaSalas.Data;
using ReservaSalas.Models;

namespace ReservaSalas.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reservas = await _context.Reservas
                .Include(r => r.Sala)
                .Include(r => r.Docente)
                .ToListAsync();

            return View(reservas);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Salas = new SelectList(
                await _context.Salas.ToListAsync(),
                "Id",
                "Codigo"
            );

            ViewBag.Docentes = new SelectList(
                await _context.Docentes.ToListAsync(),
                "Id",
                "Nome"
            );

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reserva reserva)
        {
            reserva.Finalidade = reserva.Finalidade?.Trim() ?? string.Empty;

            // Validar a data
            if (reserva.Data == default)
            {
                ModelState.AddModelError("Data", "A data é obrigatória.");
            }

            // Validar o horário
            if (reserva.HoraFim <= reserva.HoraInicio)
            {
                ModelState.AddModelError(
                    "HoraFim",
                    "A hora de fim tem de ser posterior à hora de início."
                );
            }

            // Verificar se a sala existe
            bool salaExiste = await _context.Salas
                .AnyAsync(s => s.Id == reserva.SalaId);

            if (!salaExiste)
            {
                ModelState.AddModelError("SalaId", "Selecione uma sala válida.");
            }

            // Verificar se o docente existe
            bool docenteExiste = await _context.Docentes
                .AnyAsync(d => d.Id == reserva.DocenteId);

            if (!docenteExiste)
            {
                ModelState.AddModelError("DocenteId", "Selecione um docente válido.");
            }

            // Verificar se existem conflitos de horário
            if (ModelState.IsValid)
            {
                bool conflito = await _context.Reservas.AnyAsync(r =>
                    r.SalaId == reserva.SalaId &&
                    r.Data == reserva.Data &&
                    r.HoraInicio < reserva.HoraFim &&
                    reserva.HoraInicio < r.HoraFim
                );

                if (conflito)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "A sala já está reservada nesse horário."
                    );
                }
            }

            if (ModelState.IsValid)
            {
                _context.Reservas.Add(reserva);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Voltar a carregar as listas caso existam erros
            ViewBag.Salas = new SelectList(
                await _context.Salas.ToListAsync(),
                "Id",
                "Codigo",
                reserva.SalaId
            );

            ViewBag.Docentes = new SelectList(
                await _context.Docentes.ToListAsync(),
                "Id",
                "Nome",
                reserva.DocenteId
            );

            return View(reserva);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            ViewBag.Salas = new SelectList(
                await _context.Salas.ToListAsync(),
                "Id",
                "Codigo",
                reserva.SalaId
            );

            ViewBag.Docentes = new SelectList(
                await _context.Docentes.ToListAsync(),
                "Id",
                "Nome",
                reserva.DocenteId
            );

            return View(reserva);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            var reservaExistente = await _context.Reservas.FindAsync(id);

            if (reservaExistente == null)
            {
                return NotFound();
            }

            reserva.Finalidade = reserva.Finalidade?.Trim() ?? string.Empty;

            if (reserva.Data == default)
            {
                ModelState.AddModelError("Data", "A data é obrigatória.");
            }

            if (reserva.HoraFim <= reserva.HoraInicio)
            {
                ModelState.AddModelError(
                    "HoraFim",
                    "A hora de fim tem de ser posterior à hora de início."
                );
            }

            bool salaExiste = await _context.Salas
                .AnyAsync(s => s.Id == reserva.SalaId);

            if (!salaExiste)
            {
                ModelState.AddModelError("SalaId", "Selecione uma sala válida.");
            }

            bool docenteExiste = await _context.Docentes
                .AnyAsync(d => d.Id == reserva.DocenteId);

            if (!docenteExiste)
            {
                ModelState.AddModelError("DocenteId", "Selecione um docente válido.");
            }

            if (ModelState.IsValid)
            {
                bool conflito = await _context.Reservas.AnyAsync(r =>
                    r.Id != reserva.Id &&
                    r.SalaId == reserva.SalaId &&
                    r.Data == reserva.Data &&
                    r.HoraInicio < reserva.HoraFim &&
                    reserva.HoraInicio < r.HoraFim
                );

                if (conflito)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "A sala já está reservada nesse horário."
                    );
                }
            }

            if (ModelState.IsValid)
            {
                reservaExistente.SalaId = reserva.SalaId;
                reservaExistente.DocenteId = reserva.DocenteId;
                reservaExistente.Data = reserva.Data;
                reservaExistente.HoraInicio = reserva.HoraInicio;
                reservaExistente.HoraFim = reserva.HoraFim;
                reservaExistente.Finalidade = reserva.Finalidade;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Salas = new SelectList(
                await _context.Salas.ToListAsync(),
                "Id",
                "Codigo",
                reserva.SalaId
            );

            ViewBag.Docentes = new SelectList(
                await _context.Docentes.ToListAsync(),
                "Id",
                "Nome",
                reserva.DocenteId
            );

            return View(reserva);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Sala)
                .Include(r => r.Docente)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
