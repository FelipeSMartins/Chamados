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
    public class PrioridadesController : Controller
    {
        private readonly ChamadosContext _context;

        public PrioridadesController(ChamadosContext context)
        {
            _context = context;
        }

        // GET: Prioridades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prioridade.ToListAsync());
        }

        // GET: Prioridades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridade = await _context.Prioridade
                .FirstOrDefaultAsync(m => m.PriId == id);
            if (prioridade == null)
            {
                return NotFound();
            }

            return View(prioridade);
        }

        // GET: Prioridades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prioridades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PriId,PriNome")] Prioridade prioridade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prioridade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prioridade);
        }

        // GET: Prioridades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridade = await _context.Prioridade.FindAsync(id);
            if (prioridade == null)
            {
                return NotFound();
            }
            return View(prioridade);
        }

        // POST: Prioridades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PriId,PriNome")] Prioridade prioridade)
        {
            if (id != prioridade.PriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prioridade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrioridadeExists(prioridade.PriId))
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
            return View(prioridade);
        }

        // GET: Prioridades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridade = await _context.Prioridade
                .FirstOrDefaultAsync(m => m.PriId == id);
            if (prioridade == null)
            {
                return NotFound();
            }

            return View(prioridade);
        }

        // POST: Prioridades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prioridade = await _context.Prioridade.FindAsync(id);
            _context.Prioridade.Remove(prioridade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrioridadeExists(int id)
        {
            return _context.Prioridade.Any(e => e.PriId == id);
        }
    }
}
