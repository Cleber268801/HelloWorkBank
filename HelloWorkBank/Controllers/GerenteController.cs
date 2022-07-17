using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloWorkBank.Data;
using HelloWorkBank.Models;

namespace HelloWorkBank.Controllers
{
    public class GerenteController : Controller
    {
        private readonly BankDataContext _context;

        public GerenteController(BankDataContext context)
        {
            _context = context;
        }

        // GET: Gerente
        public async Task<IActionResult> Index()
        {
              return _context.Gerentes != null ? 
                          View(await _context.Gerentes.ToListAsync()) :
                          Problem("Entity set 'BankDataContext.Gerentes'  is null.");
        }

        // GET: Gerente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gerentes == null)
            {
                return NotFound();
            }

            var gerenteModel = await _context.Gerentes
                .FirstOrDefaultAsync(m => m.IdGerente == id);
            if (gerenteModel == null)
            {
                return NotFound();
            }

            return View(gerenteModel);
        }

        // GET: Gerente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gerente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGerente,NomeGerente")] GerenteModel gerenteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerenteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gerenteModel);
        }

        // GET: Gerente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gerentes == null)
            {
                return NotFound();
            }

            var gerenteModel = await _context.Gerentes.FindAsync(id);
            if (gerenteModel == null)
            {
                return NotFound();
            }
            return View(gerenteModel);
        }

        // POST: Gerente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGerente,NomeGerente")] GerenteModel gerenteModel)
        {
            if (id != gerenteModel.IdGerente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerenteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerenteModelExists(gerenteModel.IdGerente))
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
            return View(gerenteModel);
        }

        // GET: Gerente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gerentes == null)
            {
                return NotFound();
            }

            var gerenteModel = await _context.Gerentes
                .FirstOrDefaultAsync(m => m.IdGerente == id);
            if (gerenteModel == null)
            {
                return NotFound();
            }

            return View(gerenteModel);
        }

        // POST: Gerente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gerentes == null)
            {
                return Problem("Entity set 'BankDataContext.Gerentes'  is null.");
            }
            var gerenteModel = await _context.Gerentes.FindAsync(id);
            if (gerenteModel != null)
            {
                _context.Gerentes.Remove(gerenteModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerenteModelExists(int id)
        {
          return (_context.Gerentes?.Any(e => e.IdGerente == id)).GetValueOrDefault();
        }
    }
}
