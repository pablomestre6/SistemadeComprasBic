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
    public class ReceiptNFsController : Controller
    {
        private readonly SistemadeComprasBicContext _context;

        public ReceiptNFsController(SistemadeComprasBicContext context)
        {
            _context = context;
        }

        // GET: ReceiptNFs
        public async Task<IActionResult> Index()
        {
              return _context.ReceiptNF != null ? 
                          View(await _context.ReceiptNF.ToListAsync()) :
                          Problem("Entity set 'SistemadeComprasBicContext.ReceiptNF'  is null.");
        }

        // GET: ReceiptNFs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ReceiptNF == null)
            {
                return NotFound();
            }

            var receiptNF = await _context.ReceiptNF
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receiptNF == null)
            {
                return NotFound();
            }

            return View(receiptNF);
        }

        // GET: ReceiptNFs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReceiptNFs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumberNF,Approves,NotAproves")] ReceiptNF receiptNF)
        {
            if (ModelState.IsValid)
            {
                receiptNF.Id = Guid.NewGuid();
                _context.Add(receiptNF);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receiptNF);
        }

        // GET: ReceiptNFs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ReceiptNF == null)
            {
                return NotFound();
            }

            var receiptNF = await _context.ReceiptNF.FindAsync(id);
            if (receiptNF == null)
            {
                return NotFound();
            }
            return View(receiptNF);
        }

        // POST: ReceiptNFs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,NumberNF,Approves,NotAproves")] ReceiptNF receiptNF)
        {
            if (id != receiptNF.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiptNF);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptNFExists(receiptNF.Id))
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
            return View(receiptNF);
        }

        // GET: ReceiptNFs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ReceiptNF == null)
            {
                return NotFound();
            }

            var receiptNF = await _context.ReceiptNF
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receiptNF == null)
            {
                return NotFound();
            }

            return View(receiptNF);
        }

        // POST: ReceiptNFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ReceiptNF == null)
            {
                return Problem("Entity set 'SistemadeComprasBicContext.ReceiptNF'  is null.");
            }
            var receiptNF = await _context.ReceiptNF.FindAsync(id);
            if (receiptNF != null)
            {
                _context.ReceiptNF.Remove(receiptNF);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptNFExists(Guid id)
        {
          return (_context.ReceiptNF?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
