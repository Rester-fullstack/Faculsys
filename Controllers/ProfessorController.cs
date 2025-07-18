﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FaculSys.Data;
using FaculSys.Models;

namespace FaculSys.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly AppDbContext _context;

        public ProfessorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Professor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Professores.ToListAsync());
        }

        // GET: Professor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var professor = await _context.Professores.FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null) return NotFound();

            return View(professor);
        }

        // GET: Professor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var professor = await _context.Professores.FindAsync(id);
            if (professor == null) return NotFound();

            return View(professor);
        }

        // POST: Professor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Professor professor)
        {
            if (id != professor.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var professor = await _context.Professores.FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null) return NotFound();

            return View(professor);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor != null)
            {
                _context.Professores.Remove(professor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professores.Any(e => e.Id == id);
        }
    }
}
