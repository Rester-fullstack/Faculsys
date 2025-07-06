using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FaculSys.Data;
using FaculSys.Models;

namespace FaculSys.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly AppDbContext _context;

        public MatriculaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Matricula
        public async Task<IActionResult> Index()
        {
            var matriculas = _context.Matriculas
                .Include(m => m.Aluno)
                .Include(m => m.Disciplina);
            return View(await matriculas.ToListAsync());
        }

        // GET: Matricula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var matricula = await _context.Matriculas
                .Include(m => m.Aluno)
                .Include(m => m.Disciplina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null) return NotFound();

            return View(matricula);
        }

        // GET: Matricula/Create
        public IActionResult Create()
        {
            ViewBag.AlunoId = new SelectList(_context.Alunos, "Id", "Nome");
            ViewBag.DisciplinaId = new SelectList(_context.Disciplinas, "Id", "Nome");
            return View();
        }

        // POST: Matricula/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AlunoId = new SelectList(_context.Alunos, "Id", "Nome", matricula.AlunoId);
            ViewBag.DisciplinaId = new SelectList(_context.Disciplinas, "Id", "Nome", matricula.DisciplinaId);
            return View(matricula);
        }

        // GET: Matricula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null) return NotFound();

            ViewBag.AlunoId = new SelectList(_context.Alunos, "Id", "Nome", matricula.AlunoId);
            ViewBag.DisciplinaId = new SelectList(_context.Disciplinas, "Id", "Nome", matricula.DisciplinaId);
            return View(matricula);
        }

        // POST: Matricula/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Matricula matricula)
        {
            if (id != matricula.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AlunoId = new SelectList(_context.Alunos, "Id", "Nome", matricula.AlunoId);
            ViewBag.DisciplinaId = new SelectList(_context.Disciplinas, "Id", "Nome", matricula.DisciplinaId);
            return View(matricula);
        }

        // GET: Matricula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var matricula = await _context.Matriculas
                .Include(m => m.Aluno)
                .Include(m => m.Disciplina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null) return NotFound();

            return View(matricula);
        }

        // POST: Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula != null)
            {
                _context.Matriculas.Remove(matricula);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matriculas.Any(e => e.Id == id);
        }
    }
}
