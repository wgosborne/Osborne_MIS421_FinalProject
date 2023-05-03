using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _521Final.Data;
using _521Final.Models;
using Microsoft.AspNetCore.Authorization;

namespace _521Final.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Adding the book photo
        /*public async Task<IActionResult> GetBookPhoto(int id)
        {
            var books = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }
            var imageData = books.BookPhoto;
            return File(imageData, "image/jpg");
        }*/

        // GET: Books
        //Make the GenreReport 
       


        public IActionResult GenreReport()
        {
            // Call the GetBooksByGenre method to generate the report and retrieve the list of books
            List<Book> books = GetBooksByGenre();

            // Render the report view and pass the list of books as a model
            return View("GenreReport", books);
        }

        private List<Book> GetBooksByGenre()
        {
            // Implementation of the GetBooksByGenre method goes here..
            List<Book> books = _context.Book.ToList();

            // Group the books by genre and count the number of books in each genre
            var genreCounts = books.GroupBy(b => b.Genre)
                                   .Select(g => new { Genre = g.Key, Count = g.Count() })
                                   .ToList();

            // Output the genre report to the console
            Console.WriteLine("Book Genre Report:");
            foreach (var gc in genreCounts)
            {
                Console.WriteLine($"{gc.Genre}: {gc.Count}");
            }

            // Return the list of books grouped by genre
            return books;
        }

        public async Task<IActionResult> Index()
        {
            /*var applicationDbContext = _context.Book.Include(a => a.Genre);
            return View(await applicationDbContext.ToListAsync());*/
            return _context.Book != null ?
                        View(await _context.Book.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Book'  is null.");

            //var applicationDbContext = _context.GenreBook.Include(m => m.Book).Include(m => m.Genre);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                //.Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            //this is where the twitter and VM classes were added. 

            return View(book);
        }

        // GET: Books/Create
        [Authorize("Admin")]
        public IActionResult Create()
        {
            // added the line below, may need to delete
            //ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id");
            //ViewData["GenreID"] = new SelectList(_context.Genre, "Id", "Id");
            ViewData["Genre"] = new SelectList(_context.Genre, "Name", "Name");
            var genre = _context.Genre.Where(g => g.Name == ViewData["Genre"]);
            ViewData["GenreID"] = genre;
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("User")]
        public async Task<IActionResult> Create([Bind("Id,HyperLink,Title,Author,AvgRating,Genre,Summary,GenreId")] Book book, IFormFile BookPhoto)
        {
            if (ModelState.IsValid)
            {
                if (BookPhoto != null && BookPhoto.Length > 0)
                {
                   var memoryStream = new MemoryStream();
                   await BookPhoto.CopyToAsync(memoryStream);
                   book.BookPhoto = memoryStream.ToArray();
                }
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["GenreID"] = new SelectList(_context.Genre, "Id", "Id", book.GenreId);
            ViewData["Genre"] = new SelectList(_context.Genre, "Name", "Name", book.Genre);
            return View(book);
        }

        public async Task<IActionResult> GetBookPhoto(int Id)
        {
            var books = await _context.Book.FirstOrDefaultAsync(m => m.Id == Id);
            if (books == null)
            {
                return NotFound();
            }
            var imageData = books.BookPhoto;
            return File(imageData, "image/jpg");
        }
        // GET: Books/Edit/5

        [Authorize("User")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            //ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", book.GenreId);
            ViewData["Genre"] = new SelectList(_context.Genre, "Name", "Name");
            var genre = _context.Genre.Where(g => g.Name == ViewData["Genre"]);
            ViewData["GenreID"] = genre;
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("User")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HyperLink,Title,Author,AvgRating,Genre,Summary,GenreId")] Book book, IFormFile BookPhoto)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (BookPhoto != null && BookPhoto.Length > 0)
                    {
                        var memoryStream = new MemoryStream();
                        await BookPhoto.CopyToAsync(memoryStream);
                        book.BookPhoto = memoryStream.ToArray();
                    }
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            //ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", book.GenreId);
            ViewData["Genre"] = new SelectList(_context.Genre, "Name", "Name", book.Genre);
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize("User")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                //.Include(x => x.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
      
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Book'  is null.");
            }
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (_context.Book?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
