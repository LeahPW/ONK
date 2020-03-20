using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Frontend.Data;
using ONK1.Models;

namespace Frontend.Controllers
{
    public class VaerktoejsController : Controller
    {
        private readonly FrontendContext _context;

        public VaerktoejsController(FrontendContext context)
        {
            _context = context;
        }

        // GET: Vaerktoejs
        public async Task<IActionResult> Index()
        {
            var frontendContext = _context.Vaerktoej.Include(v => v.Vaerktoejskasse);
            return View(await frontendContext.ToListAsync());
        }

        // GET: Vaerktoejs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaerktoej = await _context.Vaerktoej
                .Include(v => v.Vaerktoejskasse)
                .FirstOrDefaultAsync(m => m.VTId == id);
            if (vaerktoej == null)
            {
                return NotFound();
            }

            return View(vaerktoej);
        }

        // GET: Vaerktoejs/Create
        public IActionResult Create()
        {
            ViewData["LiggerIVTK"] = new SelectList(_context.Set<Vaerktoejskasse>(), "VTKId", "VTKId");
            return View();
        }

        // POST: Vaerktoejs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LiggerIVTK,VTAnskaffet,VTFabrikat,VTId,VTModel,VTSerienummer,VTType")] Vaerktoej vaerktoej)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaerktoej);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LiggerIVTK"] = new SelectList(_context.Set<Vaerktoejskasse>(), "VTKId", "VTKId", vaerktoej.LiggerIVTK);
            return View(vaerktoej);
        }

        // GET: Vaerktoejs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaerktoej = await _context.Vaerktoej.FindAsync(id);
            if (vaerktoej == null)
            {
                return NotFound();
            }
            ViewData["LiggerIVTK"] = new SelectList(_context.Set<Vaerktoejskasse>(), "VTKId", "VTKId", vaerktoej.LiggerIVTK);
            return View(vaerktoej);
        }

        // POST: Vaerktoejs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LiggerIVTK,VTAnskaffet,VTFabrikat,VTId,VTModel,VTSerienummer,VTType")] Vaerktoej vaerktoej)
        {
            if (id != vaerktoej.VTId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaerktoej);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaerktoejExists(vaerktoej.VTId))
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
            ViewData["LiggerIVTK"] = new SelectList(_context.Set<Vaerktoejskasse>(), "VTKId", "VTKId", vaerktoej.LiggerIVTK);
            return View(vaerktoej);
        }

        // GET: Vaerktoejs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaerktoej = await _context.Vaerktoej
                .Include(v => v.Vaerktoejskasse)
                .FirstOrDefaultAsync(m => m.VTId == id);
            if (vaerktoej == null)
            {
                return NotFound();
            }

            return View(vaerktoej);
        }

        // POST: Vaerktoejs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaerktoej = await _context.Vaerktoej.FindAsync(id);
            _context.Vaerktoej.Remove(vaerktoej);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaerktoejExists(int id)
        {
            return _context.Vaerktoej.Any(e => e.VTId == id);
        }
    }
}
