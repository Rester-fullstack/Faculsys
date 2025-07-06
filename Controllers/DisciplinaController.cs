using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FaculSys.Data;
using FaculSys.Models;

namespace FaculSys.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly AppDbContext _context;

        public DisciplinaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Disciplina
        public async Task<IActionResult> Index()
        {
            var disciplinas = _context.Disciplinas.Include(d => d.Professor);
            return View(await disciplinas.ToListAsync());
        }

        // GET: Disciplina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var disciplina = await _context.Disciplinas
                                .Include(d => d.Professor)
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplina == null) return NotFound();

            return View(disciplina);
        }

        // GET: Disciplina/Create
        public IActionResult Create()
        {
            ViewBag.Professores = new SelectList(_context.Professores, "Id", "Nome");
            return View();
        }

        // POST: Disciplina/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Professores = new SelectList(_context.Professores, "Id", "Nome", disciplina.ProfessorId);
            return View(disciplina);
        }

        // GET: Disciplina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var disciplina = await _context.Disciplinas.FindAsync(id);
            if (disciplina == null) return NotFound();

            ViewBag.Professores = new SelectList(_context.Professores, "Id", "Nome", disciplina.ProfessorId);
            return View(disciplina);
        }

        // POST: Disciplina/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Disciplina disciplina)
        {
            if (id != disciplina.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplinaExists(disciplina.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Professores = new SelectList(_context.Professores, "Id", "Nome", disciplina.ProfessorId);
            return View(disciplina);
        }

        // GET: Disciplina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var disciplina = await _context.Disciplinas
                                .Include(d => d.Professor)
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplina == null) return NotFound();

            return View(disciplina);
        }

        // POST: Disciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disciplina = await _context.Disciplinas.FindAsync(id);
            if (disciplina != null)
            {
                _context.Disciplinas.Remove(disciplina);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplinaExists(int id)
        {
            return _context.Disciplinas.Any(e => e.Id == id);
        }
    }
}
