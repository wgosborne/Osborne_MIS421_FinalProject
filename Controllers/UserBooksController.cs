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
    public class UserBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserBooks
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.MovieActor.Include(m => m.Actor).Include(m => m.Movie); we can rework this for book later
            //return View(await applicationDbContext.ToListAsync()); change this for UserBook later
            //return _context.UserBook != null ?
            //            View(await _context.UserBook.ToListAsync()) :
            //            Problem("Entity set 'ApplicationDbContext.UserBook'  is null.");
            //return View();
            var applicationDbContext = _context.UserBook.Include(m => m.Book).Include(m => m.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserBook == null)
            {
                return NotFound();
            }

            var userBook = await _context.UserBook
                .FirstOrDefaultAsync(m => m.UserBookId == id);
            if (userBook == null)
            {
                return NotFound();
            }

            return View(userBook);
        }

        // GET: UserBooks/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Book, "Id", "Title");
            ViewData["UserID"] = new SelectList(_context.User, "Id", "FirstName");
            return View();
        }

        // POST: UserBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, StartDate, EndDate, UserRating, UserReview, UserId, BookId")] UserBook userBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Book, "Id", "Title", userBook.BookId);
            ViewData["UserID"] = new SelectList(_context.User, "Id", "FirstName", userBook.UserId);
            return View(userBook);
        }

        // GET: UserBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserBook == null)
            {
                return NotFound();
            }

            var userBook = await _context.UserBook.FindAsync(id);
            if (userBook == null)
            {
                return NotFound();
            }
            return View(userBook);
        }

        // POST: UserBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, StartDate, EndDate, UserRating, UserReview, UserId, BookId")] UserBook userBook)
        {
            if (id != userBook.UserBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserBookExists(userBook.UserBookId))
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
            return View(userBook);
        }

        // GET: UserBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserBook == null)
            {
                return NotFound();
            }

            var userBook = await _context.UserBook
                .FirstOrDefaultAsync(m => m.UserBookId == id);
            if (userBook == null)
            {
                return NotFound();
            }

            return View(userBook);
        }

        // POST: UserBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserBook == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserBook'  is null.");
            }
            var userBook = await _context.UserBook.FindAsync(id);
            if (userBook != null)
            {
                _context.UserBook.Remove(userBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserBookExists(int id)
        {
          return (_context.UserBook?.Any(e => e.UserBookId == id)).GetValueOrDefault();
        }
    }
}
