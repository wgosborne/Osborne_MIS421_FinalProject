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
    public class GenreBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenreBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GenreBooks
        public async Task<IActionResult> Index()
        {
              return _context.GenreBook != null ? 
                          View(await _context.GenreBook.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GenreBook'  is null.");
        }

        // GET: GenreBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GenreBook == null)
            {
                return NotFound();
            }

            var genreBook = await _context.GenreBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genreBook == null)
            {
                return NotFound();
            }

            return View(genreBook);
        }

        // GET: GenreBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GenreBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] GenreBook genreBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genreBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genreBook);
        }

        // GET: GenreBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GenreBook == null)
            {
                return NotFound();
            }

            var genreBook = await _context.GenreBook.FindAsync(id);
            if (genreBook == null)
            {
                return NotFound();
            }
            return View(genreBook);
        }

        // POST: GenreBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] GenreBook genreBook)
        {
            if (id != genreBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genreBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreBookExists(genreBook.Id))
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
            return View(genreBook);
        }

        // GET: GenreBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GenreBook == null)
            {
                return NotFound();
            }

            var genreBook = await _context.GenreBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genreBook == null)
            {
                return NotFound();
            }

            return View(genreBook);
        }

        // POST: GenreBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GenreBook == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GenreBook'  is null.");
            }
            var genreBook = await _context.GenreBook.FindAsync(id);
            if (genreBook != null)
            {
                _context.GenreBook.Remove(genreBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreBookExists(int id)
        {
          return (_context.GenreBook?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
