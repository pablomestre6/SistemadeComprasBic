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
    public class RequestModelsController : Controller
    {
        private readonly SistemadeComprasBicContext _context;

        public RequestModelsController(SistemadeComprasBicContext context)
        {
            _context = context;
        }

        // GET: RequestModels
        public async Task<IActionResult> Index()
        {
              return _context.RequestModel != null ? 
                          View(await _context.RequestModel.ToListAsync()) :
                          Problem("Entity set 'SistemadeComprasBicContext.RequestModel'  is null.");
        }

        // GET: RequestModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.RequestModel == null)
            {
                return NotFound();
            }

            var requestModel = await _context.RequestModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestModel == null)
            {
                return NotFound();
            }

            return View(requestModel);
        }

        // GET: RequestModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductModel,RequestingSector")] RequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                requestModel.Id = Guid.NewGuid();
                _context.Add(requestModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestModel);
        }

        // GET: RequestModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.RequestModel == null)
            {
                return NotFound();
            }

            var requestModel = await _context.RequestModel.FindAsync(id);
            if (requestModel == null)
            {
                return NotFound();
            }
            return View(requestModel);
        }

        // POST: RequestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ProductModel,RequestingSector")] RequestModel requestModel)
        {
            if (id != requestModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestModelExists(requestModel.Id))
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
            return View(requestModel);
        }

        // GET: RequestModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.RequestModel == null)
            {
                return NotFound();
            }

            var requestModel = await _context.RequestModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestModel == null)
            {
                return NotFound();
            }

            return View(requestModel);
        }

        // POST: RequestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.RequestModel == null)
            {
                return Problem("Entity set 'SistemadeComprasBicContext.RequestModel'  is null.");
            }
            var requestModel = await _context.RequestModel.FindAsync(id);
            if (requestModel != null)
            {
                _context.RequestModel.Remove(requestModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestModelExists(Guid id)
        {
          return (_context.RequestModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
