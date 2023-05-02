using _521Final.Data;
using _521Final.Data.Repository.IRepository;
using _521Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _521Final.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
    
        [Authorize("Admin")]
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            var applicationUsers = users.Select(u => new ApplicationUser { Id = u.Id, UserName = u.UserName, Email = u.Email }).ToList();
            return View(applicationUsers);
        }

        public IActionResult Create()
        {
            // added the line below, may need to delete
            //ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password,FirstName,LastName,Birthday")] User user)
        {
            if (ModelState.IsValid)
            {
                //if (BookPhoto != null && BookPhoto.Length > 0)
                //{
                //    var memoryStream = new MemoryStream();
                //    await BookPhoto.CopyToAsync(memoryStream);
                //    book.BookPhoto = memoryStream.ToArray();
                //}
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Title", book.GenreId);
            return View(user);
        }

        // GET: Books/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null || _context.Book == null)
        //        {
        //            return NotFound();
        //        }

        //        var book = await _context.Book.FindAsync(id);
        //        if (book == null)
        //        {
        //            return NotFound();
        //        }
        //        //ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", book.GenreId);
        //        return View(book);
        //    }

        //    // POST: Books/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,HyperLink,Title,Author,AvgRating,Genre")] Book book)
        //    {
        //        if (id != book.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(book);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!BookExists(book.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        //ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", book.GenreId);
        //        return View(book);
        //    }

        //    // GET: Books/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null || _context.Book == null)
        //        {
        //            return NotFound();
        //        }

        //        var book = await _context.Book
        //            //.Include(x => x.Genre)
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (book == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(book);
        //    }

        //    // POST: Books/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        if (_context.Book == null)
        //        {
        //            return Problem("Entity set 'ApplicationDbContext.Book'  is null.");
        //        }
        //        var book = await _context.Book.FindAsync(id);
        //        if (book != null)
        //        {
        //            _context.Book.Remove(book);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool BookExists(int id)
        //    {
        //        return (_context.Book?.Any(e => e.Id == id)).GetValueOrDefault();
        //    }
        //}
    }
}
