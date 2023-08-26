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
    public class DepartamentModelsController : Controller
    {
        private readonly SistemadeComprasBicContext _context;

        public DepartamentModelsController(SistemadeComprasBicContext context)
        {
            _context = context;
        }

        // GET: DepartamentModels
        public async Task<IActionResult> Index()
        {
              return _context.DepartamentModel != null ? 
                          View(await _context.DepartamentModel.ToListAsync()) :
                          Problem("Entity set 'SistemadeComprasBicContext.DepartamentModel'  is null.");
        }

        // GET: DepartamentModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.DepartamentModel == null)
            {
                return NotFound();
            }

            var departamentModel = await _context.DepartamentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamentModel == null)
            {
                return NotFound();
            }

            return View(departamentModel);
        }

        // GET: DepartamentModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepartamentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameDepartament,Manager,Collaborator,DateTime")] DepartamentModel departamentModel)
        {
            if (ModelState.IsValid)
            {
                departamentModel.Id = Guid.NewGuid();
                _context.Add(departamentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamentModel);
        }

        // GET: DepartamentModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.DepartamentModel == null)
            {
                return NotFound();
            }

            var departamentModel = await _context.DepartamentModel.FindAsync(id);
            if (departamentModel == null)
            {
                return NotFound();
            }
            return View(departamentModel);
        }

        // POST: DepartamentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,NameDepartament,Manager,Collaborator,DateTime")] DepartamentModel departamentModel)
        {
            if (id != departamentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentModelExists(departamentModel.Id))
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
            return View(departamentModel);
        }

        // GET: DepartamentModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.DepartamentModel == null)
            {
                return NotFound();
            }

            var departamentModel = await _context.DepartamentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamentModel == null)
            {
                return NotFound();
            }

            return View(departamentModel);
        }

        // POST: DepartamentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.DepartamentModel == null)
            {
                return Problem("Entity set 'SistemadeComprasBicContext.DepartamentModel'  is null.");
            }
            var departamentModel = await _context.DepartamentModel.FindAsync(id);
            if (departamentModel != null)
            {
                _context.DepartamentModel.Remove(departamentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentModelExists(Guid id)
        {
          return (_context.DepartamentModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
