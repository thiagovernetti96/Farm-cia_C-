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
    public class ProdutosController : Controller
    {
        private readonly Farmácia_C_Context _context;

        public ProdutosController(Farmácia_C_Context context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var farmácia_C_Context = _context.Produto.Include("Fornecedor");
            return View(await farmácia_C_Context.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["FornecedorID"] = new SelectList(_context.Fornecedor, "Id", "Name");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Data_De_Entrada,Validade,Preco,FornecedorID,Quantidade")] Produto produto)
        {
            var produtoExistente = _context.Produto.FirstOrDefault(p => p.Nome == produto.Nome);

            if (produtoExistente != null)
            {
                produtoExistente.Quantidade += produto.Quantidade;
                _context.Update(produtoExistente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            if (produtoExistente == null)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorID"] = new SelectList(_context.Fornecedor, "Id", "Id", produto.FornecedorID);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["FornecedorID"] = new SelectList(_context.Fornecedor, "Id", "Name", produto.FornecedorID);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Data_De_Entrada,Validade,Preco,FornecedorID,Quantidade")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

           
                _context.Update(produto);
                await _context.SaveChangesAsync();
            
              
            return RedirectToAction(nameof(Index));
            
            ViewData["FornecedorID"] = new SelectList(_context.Fornecedor, "Id", "Id", produto.FornecedorID);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produto == null)
            {
                return Problem("Entity set 'Farmácia_C_Context.Produto'  is null.");
            }
            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
            {
                _context.Produto.Remove(produto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
          return (_context.Produto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
