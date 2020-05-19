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
    public class DepartamentoAtendentesController : Controller
    {
        private readonly ChamadosContext _context;

        public DepartamentoAtendentesController(ChamadosContext context)
        {
            _context = context;
        }

        // GET: DepartamentoAtendentes
        public async Task<IActionResult> Index()
        {
            var chamadosContext = _context.DepartamentoAtendente.Include(d => d.DaAtendente).Include(d => d.DaDepartamento);
            return View(await chamadosContext.ToListAsync());
        }

        // GET: DepartamentoAtendentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentoAtendente = await _context.DepartamentoAtendente
                .Include(d => d.DaAtendente)
                .Include(d => d.DaDepartamento)
                .FirstOrDefaultAsync(m => m.DaDepartamentoid == id);
            if (departamentoAtendente == null)
            {
                return NotFound();
            }

            return View(departamentoAtendente);
        }

        // GET: DepartamentoAtendentes/Create
        public IActionResult Create()
        {
            ViewData["DaAtendenteid"] = new SelectList(_context.Atendente, "AteId", "AteId");
            ViewData["DaDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail");
            return View();
        }

        // POST: DepartamentoAtendentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DaDepartamentoid,DaAtendenteid")] DepartamentoAtendente departamentoAtendente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamentoAtendente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DaAtendenteid"] = new SelectList(_context.Atendente, "AteId", "AteId", departamentoAtendente.DaAtendenteid);
            ViewData["DaDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail", departamentoAtendente.DaDepartamentoid);
            return View(departamentoAtendente);
        }

        // GET: DepartamentoAtendentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentoAtendente = await _context.DepartamentoAtendente.FindAsync(id);
            if (departamentoAtendente == null)
            {
                return NotFound();
            }
            ViewData["DaAtendenteid"] = new SelectList(_context.Atendente, "AteId", "AteId", departamentoAtendente.DaAtendenteid);
            ViewData["DaDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail", departamentoAtendente.DaDepartamentoid);
            return View(departamentoAtendente);
        }

        // POST: DepartamentoAtendentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DaDepartamentoid,DaAtendenteid")] DepartamentoAtendente departamentoAtendente)
        {
            if (id != departamentoAtendente.DaDepartamentoid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamentoAtendente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoAtendenteExists(departamentoAtendente.DaDepartamentoid))
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
            ViewData["DaAtendenteid"] = new SelectList(_context.Atendente, "AteId", "AteId", departamentoAtendente.DaAtendenteid);
            ViewData["DaDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail", departamentoAtendente.DaDepartamentoid);
            return View(departamentoAtendente);
        }

        // GET: DepartamentoAtendentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentoAtendente = await _context.DepartamentoAtendente
                .Include(d => d.DaAtendente)
                .Include(d => d.DaDepartamento)
                .FirstOrDefaultAsync(m => m.DaDepartamentoid == id);
            if (departamentoAtendente == null)
            {
                return NotFound();
            }

            return View(departamentoAtendente);
        }

        // POST: DepartamentoAtendentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamentoAtendente = await _context.DepartamentoAtendente.FindAsync(id);
            _context.DepartamentoAtendente.Remove(departamentoAtendente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoAtendenteExists(int id)
        {
            return _context.DepartamentoAtendente.Any(e => e.DaDepartamentoid == id);
        }
    }
}
