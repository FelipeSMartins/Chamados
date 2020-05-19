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
    public class ClientesController : Controller
    {
        private readonly ChamadosContext _context;

        public ClientesController(ChamadosContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var chamadosContext = _context.Cliente.Include(c => c.CliOrganizacao).Include(c => c.CliPessoa);
            return View(await chamadosContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.CliOrganizacao)
                .Include(c => c.CliPessoa)
                .FirstOrDefaultAsync(m => m.CliId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["CliOrganizacaoid"] = new SelectList(_context.Organizacao, "OrgId", "OrgCnpj");
            ViewData["CliPessoaid"] = new SelectList(_context.Pessoa, "PesId", "PesEmail");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CliId,CliPessoaid,CliOrganizacaoid")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CliOrganizacaoid"] = new SelectList(_context.Organizacao, "OrgId", "OrgCnpj", cliente.CliOrganizacaoid);
            ViewData["CliPessoaid"] = new SelectList(_context.Pessoa, "PesId", "PesEmail", cliente.CliPessoaid);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["CliOrganizacaoid"] = new SelectList(_context.Organizacao, "OrgId", "OrgCnpj", cliente.CliOrganizacaoid);
            ViewData["CliPessoaid"] = new SelectList(_context.Pessoa, "PesId", "PesEmail", cliente.CliPessoaid);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CliId,CliPessoaid,CliOrganizacaoid")] Cliente cliente)
        {
            if (id != cliente.CliId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.CliId))
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
            ViewData["CliOrganizacaoid"] = new SelectList(_context.Organizacao, "OrgId", "OrgCnpj", cliente.CliOrganizacaoid);
            ViewData["CliPessoaid"] = new SelectList(_context.Pessoa, "PesId", "PesEmail", cliente.CliPessoaid);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.CliOrganizacao)
                .Include(c => c.CliPessoa)
                .FirstOrDefaultAsync(m => m.CliId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.CliId == id);
        }
    }
}
