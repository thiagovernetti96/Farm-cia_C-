using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Farmácia_C_.Data;
using Farmácia_C_.Models;

namespace Farmácia_C_.Controllers
{
    public class ComprasController : Controller
    {
        private readonly Farmácia_C_Context _context;

        public ComprasController(Farmácia_C_Context context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var farmácia_C_Context = _context.Compra.Include(c => c.Cliente).Include(c => c.Funcionario).Include(c => c.Produto);
            return View(await farmácia_C_Context.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Compra == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .Include(c => c.Cliente)
                .Include(c => c.Funcionario)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Name");
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Name");
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Nome");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,FuncionarioId,ProdutoId,Quantidade")] Compra compra)
        {
            var produto = _context.Produto.FirstOrDefault(p => p.Id == compra.ProdutoId);

            if (produto.Quantidade < compra.Quantidade )
            {
                return BadRequest("Quantidade insuficiente no estoque");
            }
            if ( produto.Quantidade >= compra.Quantidade)
            {
                produto.Quantidade -= compra.Quantidade;
               
                _context.Update(produto);
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", compra.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Id", compra.FuncionarioId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", compra.ProdutoId);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Compra == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", compra.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Id", compra.FuncionarioId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", compra.ProdutoId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,FuncionarioId,ProdutoId,Quantidade")] Compra compra)
        {
            if (id != compra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", compra.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Id", compra.FuncionarioId);
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "Id", compra.ProdutoId);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Compra == null)
            {
                return NotFound();
            }

            var compra = await _context.Compra
                .Include(c => c.Cliente)
                .Include(c => c.Funcionario)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Compra == null)
            {
                return Problem("Entity set 'Farmácia_C_Context.Compra'  is null.");
            }
            var compra = await _context.Compra.FindAsync(id);
            if (compra != null)
            {
                _context.Compra.Remove(compra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
          return (_context.Compra?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
