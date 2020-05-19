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
    public class StatusChamadoesController : Controller
    {
        private readonly ChamadosContext _context;

        public StatusChamadoesController(ChamadosContext context)
        {
            _context = context;
        }

        // GET: StatusChamadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusChamado.ToListAsync());
        }

        // GET: StatusChamadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusChamado = await _context.StatusChamado
                .FirstOrDefaultAsync(m => m.SchaId == id);
            if (statusChamado == null)
            {
                return NotFound();
            }

            return View(statusChamado);
        }

        // GET: StatusChamadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusChamadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchaId,SchaNome")] StatusChamado statusChamado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusChamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusChamado);
        }

        // GET: StatusChamadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusChamado = await _context.StatusChamado.FindAsync(id);
            if (statusChamado == null)
            {
                return NotFound();
            }
            return View(statusChamado);
        }

        // POST: StatusChamadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SchaId,SchaNome")] StatusChamado statusChamado)
        {
            if (id != statusChamado.SchaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusChamado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusChamadoExists(statusChamado.SchaId))
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
            return View(statusChamado);
        }

        // GET: StatusChamadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusChamado = await _context.StatusChamado
                .FirstOrDefaultAsync(m => m.SchaId == id);
            if (statusChamado == null)
            {
                return NotFound();
            }

            return View(statusChamado);
        }

        // POST: StatusChamadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusChamado = await _context.StatusChamado.FindAsync(id);
            _context.StatusChamado.Remove(statusChamado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusChamadoExists(int id)
        {
            return _context.StatusChamado.Any(e => e.SchaId == id);
        }
    }
}
