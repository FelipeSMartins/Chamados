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
    public class ChamadosController : Controller
    {
        private readonly ChamadosContext _context;

        public ChamadosController(ChamadosContext context)
        {
            _context = context;
        }

        // GET: Chamadoes
        public async Task<IActionResult> Index()
        {
            var chamadosContext = _context.Chamado.Include(c => c.ChaAtendente).Include(c => c.ChaCategoria).Include(c => c.ChaCliente).Include(c => c.ChaDepartamento).Include(c => c.ChaPrioridade).Include(c => c.ChaStatus);
            return View(await chamadosContext.ToListAsync());
        }

        // GET: Chamadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamado
                .Include(c => c.ChaAtendente)
                .Include(c => c.ChaCategoria)
                .Include(c => c.ChaCliente)
                .Include(c => c.ChaDepartamento)
                .Include(c => c.ChaPrioridade)
                .Include(c => c.ChaStatus)
                .FirstOrDefaultAsync(m => m.ChaId == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // GET: Chamadoes/Create
        public IActionResult Create()
        {
            ViewData["ChaAtendenteid"] = new SelectList(_context.Atendente, "AteId", "AteId");
            ViewData["ChaCategoriaid"] = new SelectList(_context.Categoria, "CatId", "CatNome");
            ViewData["ChaClienteid"] = new SelectList(_context.Cliente, "CliId", "CliId");
            ViewData["ChaDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail");
            ViewData["ChaPrioridadeid"] = new SelectList(_context.Prioridade, "PriId", "PriNome");
            ViewData["ChaStatusid"] = new SelectList(_context.StatusChamado, "SchaId", "SchaNome");
            return View();
        }

        // POST: Chamadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChaId,ChaTitulo,ChaAssunto,ChaDescricao,ChaClienteid,ChaAtendenteid,ChaDepartamentoid,ChaCategoriaid,ChaPrioridadeid,ChaStatusid,ChaData,ChaCriador")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChaAtendenteid"] = new SelectList(_context.Atendente, "AteId", "AteId", chamado.ChaAtendenteid);
            ViewData["ChaCategoriaid"] = new SelectList(_context.Categoria, "CatId", "CatNome", chamado.ChaCategoriaid);
            ViewData["ChaClienteid"] = new SelectList(_context.Cliente, "CliId", "CliId", chamado.ChaClienteid);
            ViewData["ChaDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail", chamado.ChaDepartamentoid);
            ViewData["ChaPrioridadeid"] = new SelectList(_context.Prioridade, "PriId", "PriNome", chamado.ChaPrioridadeid);
            ViewData["ChaStatusid"] = new SelectList(_context.StatusChamado, "SchaId", "SchaNome", chamado.ChaStatusid);
            return View(chamado);
        }

        // GET: Chamadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamado.FindAsync(id);
            if (chamado == null)
            {
                return NotFound();
            }
            ViewData["ChaAtendenteid"] = new SelectList(_context.Atendente, "AteId", "AteId", chamado.ChaAtendenteid);
            ViewData["ChaCategoriaid"] = new SelectList(_context.Categoria, "CatId", "CatNome", chamado.ChaCategoriaid);
            ViewData["ChaClienteid"] = new SelectList(_context.Cliente, "CliId", "CliId", chamado.ChaClienteid);
            ViewData["ChaDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail", chamado.ChaDepartamentoid);
            ViewData["ChaPrioridadeid"] = new SelectList(_context.Prioridade, "PriId", "PriNome", chamado.ChaPrioridadeid);
            ViewData["ChaStatusid"] = new SelectList(_context.StatusChamado, "SchaId", "SchaNome", chamado.ChaStatusid);
            return View(chamado);
        }

        // POST: Chamadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChaId,ChaTitulo,ChaAssunto,ChaDescricao,ChaClienteid,ChaAtendenteid,ChaDepartamentoid,ChaCategoriaid,ChaPrioridadeid,ChaStatusid,ChaData,ChaCriador")] Chamado chamado)
        {
            if (id != chamado.ChaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamadoExists(chamado.ChaId))
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
            ViewData["ChaAtendenteid"] = new SelectList(_context.Atendente, "AteId", "AteId", chamado.ChaAtendenteid);
            ViewData["ChaCategoriaid"] = new SelectList(_context.Categoria, "CatId", "CatNome", chamado.ChaCategoriaid);
            ViewData["ChaClienteid"] = new SelectList(_context.Cliente, "CliId", "CliId", chamado.ChaClienteid);
            ViewData["ChaDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail", chamado.ChaDepartamentoid);
            ViewData["ChaPrioridadeid"] = new SelectList(_context.Prioridade, "PriId", "PriNome", chamado.ChaPrioridadeid);
            ViewData["ChaStatusid"] = new SelectList(_context.StatusChamado, "SchaId", "SchaNome", chamado.ChaStatusid);
            return View(chamado);
        }

        // GET: Chamadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamado
                .Include(c => c.ChaAtendente)
                .Include(c => c.ChaCategoria)
                .Include(c => c.ChaCliente)
                .Include(c => c.ChaDepartamento)
                .Include(c => c.ChaPrioridade)
                .Include(c => c.ChaStatus)
                .FirstOrDefaultAsync(m => m.ChaId == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // POST: Chamadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chamado = await _context.Chamado.FindAsync(id);
            _context.Chamado.Remove(chamado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamadoExists(int id)
        {
            return _context.Chamado.Any(e => e.ChaId == id);
        }
    }
}
