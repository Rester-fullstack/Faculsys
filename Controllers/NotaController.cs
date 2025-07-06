using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FaculSys.Data;
using FaculSys.Models;
using System.Linq;

namespace FaculSys.Controllers
{
    public class NotaController : Controller
    {
        private readonly AppDbContext _context;

        public NotaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Nota
        public async Task<IActionResult> Index()
        {
            var notas = _context.Notas
                .Include(n => n.Matricula)
                .ThenInclude(m => m.Aluno)
                .Include(n => n.Matricula)
                .ThenInclude(m => m.Disciplina);

            return View(await notas.ToListAsync());
        }

        // GET: Nota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var nota = await _context.Notas
                .Include(n => n.Matricula)
                .ThenInclude(m => m.Aluno)
                .Include(n => n.Matricula)
                .ThenInclude(m => m.Disciplina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null) return NotFound();

            return View(nota);
        }

        // GET: Nota/Create
        public IActionResult Create()
        {
            ViewBag.MatriculaId = GetMatriculasSelectList();
            return View();
        }

        // POST: Nota/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Nota nota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MatriculaId = GetMatriculasSelectList(nota.MatriculaId);
            return View(nota);
        }

        // GET: Nota/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var nota = await _context.Notas.FindAsync(id);
            if (nota == null) return NotFound();

            ViewBag.MatriculaId = GetMatriculasSelectList(nota.MatriculaId);
            return View(nota);
        }

        // POST: Nota/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Nota nota)
        {
            if (id != nota.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaExists(nota.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MatriculaId = GetMatriculasSelectList(nota.MatriculaId);
            return View(nota);
        }

        // GET: Nota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var nota = await _context.Notas
                .Include(n => n.Matricula)
                .ThenInclude(m => m.Aluno)
                .Include(n => n.Matricula)
                .ThenInclude(m => m.Disciplina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null) return NotFound();

            return View(nota);
        }

        // POST: Nota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nota = await _context.Notas.FindAsync(id);
            if (nota != null)
            {
                _context.Notas.Remove(nota);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool NotaExists(int id)
        {
            return _context.Notas.Any(e => e.Id == id);
        }

        // Método para montar o SelectList com descrição personalizada
        private SelectList GetMatriculasSelectList(int? selectedId = null)
        {
            var matriculas = _context.Matriculas
                .Include(m => m.Aluno)
                .Include(m => m.Disciplina)
                .AsEnumerable() // para usar LINQ to Objects
                .Select(m => new
                {
                    m.Id,
                    Descricao = $"{m.Aluno.Nome} - {m.Disciplina.Nome}"
                }).ToList();

            return new SelectList(matriculas, "Id", "Descricao", selectedId);
        }
    }
}
