using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _521Final.Data;
using _521Final.Models;

namespace _521Final.Controllers
{
    public class ReccomendationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReccomendationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reccomendations
        public async Task<IActionResult> Index()
        {
              return _context.Reccomendation != null ? 
                          View(await _context.Reccomendation.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Reccomendation'  is null.");
        }

        // GET: Reccomendations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reccomendation == null)
            {
                return NotFound();
            }

            var reccomendation = await _context.Reccomendation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reccomendation == null)
            {
                return NotFound();
            }

            return View(reccomendation);
        }

        // GET: Reccomendations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reccomendations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Reccomendation reccomendation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reccomendation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reccomendation);
        }

        // GET: Reccomendations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reccomendation == null)
            {
                return NotFound();
            }

            var reccomendation = await _context.Reccomendation.FindAsync(id);
            if (reccomendation == null)
            {
                return NotFound();
            }
            return View(reccomendation);
        }

        // POST: Reccomendations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Reccomendation reccomendation)
        {
            if (id != reccomendation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reccomendation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReccomendationExists(reccomendation.Id))
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
            return View(reccomendation);
        }

        // GET: Reccomendations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reccomendation == null)
            {
                return NotFound();
            }

            var reccomendation = await _context.Reccomendation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reccomendation == null)
            {
                return NotFound();
            }

            return View(reccomendation);
        }

        // POST: Reccomendations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reccomendation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reccomendation'  is null.");
            }
            var reccomendation = await _context.Reccomendation.FindAsync(id);
            if (reccomendation != null)
            {
                _context.Reccomendation.Remove(reccomendation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReccomendationExists(int id)
        {
          return (_context.Reccomendation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
