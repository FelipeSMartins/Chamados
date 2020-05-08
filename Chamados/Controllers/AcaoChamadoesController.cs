using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class AcaoChamadoesController : Controller
    {
        private readonly ChamadosContext _context;

        public AcaoChamadoesController(ChamadosContext context)
        {
            _context = context;
        }

        // GET: AcaoChamadoes
        public async Task<IActionResult> Index()
        {
            var chamadosContext = _context.AcaoChamado.Include(a => a.AcaoAtendente).Include(a => a.AcaoCategoria).Include(a => a.AcaoChamadoNavigation).Include(a => a.AcaoDepartamento);
            return View(await chamadosContext.ToListAsync());
        }

        // GET: AcaoChamadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acaoChamado = await _context.AcaoChamado
                .Include(a => a.AcaoAtendente)
                .Include(a => a.AcaoCategoria)
                .Include(a => a.AcaoChamadoNavigation)
                .Include(a => a.AcaoDepartamento)
                .FirstOrDefaultAsync(m => m.AcaoId == id);
            if (acaoChamado == null)
            {
                return NotFound();
            }

            return View(acaoChamado);
        }

        // GET: AcaoChamadoes/Create
        public IActionResult Create()
        {
            ViewData["AcaoAtendenteid"] = new SelectList(_context.Atendente, "AteId", "AteId");
            ViewData["AcaoCategoriaid"] = new SelectList(_context.Categoria, "CatId", "CatNome");
            ViewData["AcaoChamadoid"] = new SelectList(_context.Chamado, "ChaId", "ChaCriador");
            ViewData["AcaoDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail");
            return View();
        }

        // POST: AcaoChamadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcaoId,AcaoChamadoid,AcaoDescricao,AcaoAtendenteid,AcaoDepartamentoid,AcaoCategoriaid")] AcaoChamado acaoChamado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acaoChamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcaoAtendenteid"] = new SelectList(_context.Atendente, "AteId", "AteId", acaoChamado.AcaoAtendenteid);
            ViewData["AcaoCategoriaid"] = new SelectList(_context.Categoria, "CatId", "CatNome", acaoChamado.AcaoCategoriaid);
            ViewData["AcaoChamadoid"] = new SelectList(_context.Chamado, "ChaId", "ChaCriador", acaoChamado.AcaoChamadoid);
            ViewData["AcaoDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail", acaoChamado.AcaoDepartamentoid);
            return View(acaoChamado);
        }

        // GET: AcaoChamadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acaoChamado = await _context.AcaoChamado.FindAsync(id);
            if (acaoChamado == null)
            {
                return NotFound();
            }
            ViewData["AcaoAtendenteid"] = new SelectList(_context.Atendente, "AteId", "AteId", acaoChamado.AcaoAtendenteid);
            ViewData["AcaoCategoriaid"] = new SelectList(_context.Categoria, "CatId", "CatNome", acaoChamado.AcaoCategoriaid);
            ViewData["AcaoChamadoid"] = new SelectList(_context.Chamado, "ChaId", "ChaCriador", acaoChamado.AcaoChamadoid);
            ViewData["AcaoDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail", acaoChamado.AcaoDepartamentoid);
            return View(acaoChamado);
        }

        // POST: AcaoChamadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcaoId,AcaoChamadoid,AcaoDescricao,AcaoAtendenteid,AcaoDepartamentoid,AcaoCategoriaid")] AcaoChamado acaoChamado)
        {
            if (id != acaoChamado.AcaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acaoChamado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcaoChamadoExists(acaoChamado.AcaoId))
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
            ViewData["AcaoAtendenteid"] = new SelectList(_context.Atendente, "AteId", "AteId", acaoChamado.AcaoAtendenteid);
            ViewData["AcaoCategoriaid"] = new SelectList(_context.Categoria, "CatId", "CatNome", acaoChamado.AcaoCategoriaid);
            ViewData["AcaoChamadoid"] = new SelectList(_context.Chamado, "ChaId", "ChaCriador", acaoChamado.AcaoChamadoid);
            ViewData["AcaoDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail", acaoChamado.AcaoDepartamentoid);
            return View(acaoChamado);
        }

        // GET: AcaoChamadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acaoChamado = await _context.AcaoChamado
                .Include(a => a.AcaoAtendente)
                .Include(a => a.AcaoCategoria)
                .Include(a => a.AcaoChamadoNavigation)
                .Include(a => a.AcaoDepartamento)
                .FirstOrDefaultAsync(m => m.AcaoId == id);
            if (acaoChamado == null)
            {
                return NotFound();
            }

            return View(acaoChamado);
        }

        // POST: AcaoChamadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acaoChamado = await _context.AcaoChamado.FindAsync(id);
            _context.AcaoChamado.Remove(acaoChamado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcaoChamadoExists(int id)
        {
            return _context.AcaoChamado.Any(e => e.AcaoId == id);
        }
    }
}
