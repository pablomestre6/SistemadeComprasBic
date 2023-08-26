using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemadeComprasBic.Models;

namespace SistemadeComprasBic.Controllers
{
    public class SuppliersRegistrationsController : Controller
    {
        private readonly SistemadeComprasBicContext _context;

        public SuppliersRegistrationsController(SistemadeComprasBicContext context)
        {
            _context = context;
        }

        // GET: SuppliersRegistrations
        public async Task<IActionResult> Index()
        {
              return _context.SuppliersRegistration != null ? 
                          View(await _context.SuppliersRegistration.ToListAsync()) :
                          Problem("Entity set 'SistemadeComprasBicContext.SuppliersRegistration'  is null.");
        }

        // GET: SuppliersRegistrations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.SuppliersRegistration == null)
            {
                return NotFound();
            }

            var suppliersRegistration = await _context.SuppliersRegistration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suppliersRegistration == null)
            {
                return NotFound();
            }

            return View(suppliersRegistration);
        }

        // GET: SuppliersRegistrations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuppliersRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Company,EmailSupplier,CNPJ,Phone")] SuppliersRegistration suppliersRegistration)
        {
            if (ModelState.IsValid)
            {
                suppliersRegistration.Id = Guid.NewGuid();
                _context.Add(suppliersRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suppliersRegistration);
        }

        // GET: SuppliersRegistrations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.SuppliersRegistration == null)
            {
                return NotFound();
            }

            var suppliersRegistration = await _context.SuppliersRegistration.FindAsync(id);
            if (suppliersRegistration == null)
            {
                return NotFound();
            }
            return View(suppliersRegistration);
        }

        // POST: SuppliersRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Company,EmailSupplier,CNPJ,Phone")] SuppliersRegistration suppliersRegistration)
        {
            if (id != suppliersRegistration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suppliersRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuppliersRegistrationExists(suppliersRegistration.Id))
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
            return View(suppliersRegistration);
        }

        // GET: SuppliersRegistrations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.SuppliersRegistration == null)
            {
                return NotFound();
            }

            var suppliersRegistration = await _context.SuppliersRegistration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suppliersRegistration == null)
            {
                return NotFound();
            }

            return View(suppliersRegistration);
        }

        // POST: SuppliersRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.SuppliersRegistration == null)
            {
                return Problem("Entity set 'SistemadeComprasBicContext.SuppliersRegistration'  is null.");
            }
            var suppliersRegistration = await _context.SuppliersRegistration.FindAsync(id);
            if (suppliersRegistration != null)
            {
                _context.SuppliersRegistration.Remove(suppliersRegistration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuppliersRegistrationExists(Guid id)
        {
          return (_context.SuppliersRegistration?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
