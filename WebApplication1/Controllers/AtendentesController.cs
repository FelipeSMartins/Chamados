using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace Chamados.Controllers
{
    public class AtendentesController : Controller
    {
        private readonly ChamadosContext _context;

        public AtendentesController(ChamadosContext context)
        {
            _context = context;
        }

        // GET: Atendentes
        public async Task<IActionResult> Index()
        {
            var chamadosContext = _context.Atendente.Include(a => a.AtePessoa);
            return View(await chamadosContext.ToListAsync());
        }

        // GET: Atendentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendente = await _context.Atendente
                .Include(a => a.AtePessoa)
                .FirstOrDefaultAsync(m => m.AteId == id);
            if (atendente == null)
            {
                return NotFound();
            }

            return View(atendente);
        }

        // GET: Atendentes/Create
        public IActionResult Create()
        {
            ViewData["AtePessoaid"] = new SelectList(_context.Pessoa, "PesId", "PesEmail");
            return View();
        }

        // POST: Atendentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AteId,AtePessoaid")] Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atendente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtePessoaid"] = new SelectList(_context.Pessoa, "PesId", "PesEmail", atendente.AtePessoaid);
            return View(atendente);
        }

        // GET: Atendentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendente = await _context.Atendente.FindAsync(id);
            if (atendente == null)
            {
                return NotFound();
            }
            ViewData["AtePessoaid"] = new SelectList(_context.Pessoa, "PesId", "PesEmail", atendente.AtePessoaid);
            return View(atendente);
        }

        // POST: Atendentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AteId,AtePessoaid")] Atendente atendente)
        {
            if (id != atendente.AteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendenteExists(atendente.AteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtePessoaid"] = new SelectList(_context.Pessoa, "PesId", "PesEmail", atendente.AtePessoaid);
            return View(atendente);
        }

        // GET: Atendentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendente = await _context.Atendente
                .Include(a => a.AtePessoa)
                .FirstOrDefaultAsync(m => m.AteId == id);
            if (atendente == null)
            {
                return NotFound();
            }

            return View(atendente);
        }

        // POST: Atendentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atendente = await _context.Atendente.FindAsync(id);
            _context.Atendente.Remove(atendente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendenteExists(int id)
        {
            return _context.Atendente.Any(e => e.AteId == id);
        }
    }
}
