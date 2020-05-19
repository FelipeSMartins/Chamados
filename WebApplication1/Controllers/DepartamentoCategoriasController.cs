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
    public class DepartamentoCategoriasController : Controller
    {
        private readonly ChamadosContext _context;

        public DepartamentoCategoriasController(ChamadosContext context)
        {
            _context = context;
        }

        // GET: DepartamentoCategorias
        public async Task<IActionResult> Index()
        {
            var chamadosContext = _context.DepartamentoCategoria.Include(d => d.DcCategoria).Include(d => d.DcDepartamento);
            return View(await chamadosContext.ToListAsync());
        }

        // GET: DepartamentoCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentoCategoria = await _context.DepartamentoCategoria
                .Include(d => d.DcCategoria)
                .Include(d => d.DcDepartamento)
                .FirstOrDefaultAsync(m => m.DcDepartamentoid == id);
            if (departamentoCategoria == null)
            {
                return NotFound();
            }

            return View(departamentoCategoria);
        }

        // GET: DepartamentoCategorias/Create
        public IActionResult Create()
        {
            ViewData["DcCategoriaid"] = new SelectList(_context.Categoria, "CatId", "CatNome");
            ViewData["DcDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail");
            return View();
        }

        // POST: DepartamentoCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DcDepartamentoid,DcCategoriaid")] DepartamentoCategoria departamentoCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamentoCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DcCategoriaid"] = new SelectList(_context.Categoria, "CatId", "CatNome", departamentoCategoria.DcCategoriaid);
            ViewData["DcDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail", departamentoCategoria.DcDepartamentoid);
            return View(departamentoCategoria);
        }

        // GET: DepartamentoCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentoCategoria = await _context.DepartamentoCategoria.FindAsync(id);
            if (departamentoCategoria == null)
            {
                return NotFound();
            }
            ViewData["DcCategoriaid"] = new SelectList(_context.Categoria, "CatId", "CatNome", departamentoCategoria.DcCategoriaid);
            ViewData["DcDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail", departamentoCategoria.DcDepartamentoid);
            return View(departamentoCategoria);
        }

        // POST: DepartamentoCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DcDepartamentoid,DcCategoriaid")] DepartamentoCategoria departamentoCategoria)
        {
            if (id != departamentoCategoria.DcDepartamentoid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamentoCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoCategoriaExists(departamentoCategoria.DcDepartamentoid))
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
            ViewData["DcCategoriaid"] = new SelectList(_context.Categoria, "CatId", "CatNome", departamentoCategoria.DcCategoriaid);
            ViewData["DcDepartamentoid"] = new SelectList(_context.Departamento, "DepId", "DepEmail", departamentoCategoria.DcDepartamentoid);
            return View(departamentoCategoria);
        }

        // GET: DepartamentoCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentoCategoria = await _context.DepartamentoCategoria
                .Include(d => d.DcCategoria)
                .Include(d => d.DcDepartamento)
                .FirstOrDefaultAsync(m => m.DcDepartamentoid == id);
            if (departamentoCategoria == null)
            {
                return NotFound();
            }

            return View(departamentoCategoria);
        }

        // POST: DepartamentoCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamentoCategoria = await _context.DepartamentoCategoria.FindAsync(id);
            _context.DepartamentoCategoria.Remove(departamentoCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoCategoriaExists(int id)
        {
            return _context.DepartamentoCategoria.Any(e => e.DcDepartamentoid == id);
        }
    }
}
