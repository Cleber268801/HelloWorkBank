using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloWorkBank.Data;
using HelloWorkBank.Model;

namespace HelloWorkBank.Controllers
{
    public class ContaController : Controller
    {
        private readonly BankDataContext _context;

        public ContaController(BankDataContext context)
        {
            _context = context;
        }

        // GET: Conta
        public async Task<IActionResult> Index()
        {
              return _context.Conta != null ? 
                          View(await _context.Conta.ToListAsync()) :
                          Problem("Entity set 'BankDataContext.Conta'  is null.");
        }

        // GET: Conta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conta == null)
            {
                return NotFound();
            }

            var contaModel = await _context.Conta
                .FirstOrDefaultAsync(m => m.IdConta == id);
            if (contaModel == null)
            {
                return NotFound();
            }

            return View(contaModel);
        }

        // GET: Conta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConta,NomeConta")] ContaModel contaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contaModel);
        }

        // GET: Conta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conta == null)
            {
                return NotFound();
            }

            var contaModel = await _context.Conta.FindAsync(id);
            if (contaModel == null)
            {
                return NotFound();
            }
            return View(contaModel);
        }

        // POST: Conta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConta,NomeConta")] ContaModel contaModel)
        {
            if (id != contaModel.IdConta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaModelExists(contaModel.IdConta))
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
            return View(contaModel);
        }

        // GET: Conta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conta == null)
            {
                return NotFound();
            }

            var contaModel = await _context.Conta
                .FirstOrDefaultAsync(m => m.IdConta == id);
            if (contaModel == null)
            {
                return NotFound();
            }

            return View(contaModel);
        }

        // POST: Conta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conta == null)
            {
                return Problem("Entity set 'BankDataContext.Conta'  is null.");
            }
            var contaModel = await _context.Conta.FindAsync(id);
            if (contaModel != null)
            {
                _context.Conta.Remove(contaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaModelExists(int id)
        {
          return (_context.Conta?.Any(e => e.IdConta == id)).GetValueOrDefault();
        }
    }
}
