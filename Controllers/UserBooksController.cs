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
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;



namespace _521Final.Controllers
{
    [Authorize]
    public class UserBooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        //private ApplicationUser User;

        public UserBooksController(UserManager<IdentityUser> userManager, ApplicationDbContext dbContext) //, ApplicationUser User
        {
            _userManager = userManager;
            _context = dbContext; 
        }

        //[HttpGet]
        //public async Task<IActionResult> AddToUserAccount(int bookId)
        //{
        //    string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    // Create a new UserBook object
        //    UserBook userBook = new UserBook
        //    {
        //        UserId = userId,
        //        BookId = bookId
        //    };



        //    // Add the UserBook to the database
        //    _context.UserBook.Add(userBook);
        //    await _context.SaveChangesAsync();



        //    return RedirectToAction("Index", "Books");
        //}

        //decide who needs to be authorized here I TOOK THIS OUT

        [Authorize("User")]
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.MovieActor.Include(m => m.Actor).Include(m => m.Movie); we can rework this for book later
            //return View(await applicationDbContext.ToListAsync()); change this for UserBook later
            //return _context.UserBook != null ?
            //            View(await _context.UserBook.ToListAsync()) :
            //            Problem("Entity set 'ApplicationDbContext.UserBook'  is null.");
            //return View();
            //var applicationDbContext = _context.UserBook.Include(m => m.Book).Include(m => m.UserId);
            //return View(await applicationDbContext.ToListAsync());

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }



            var userBooks = await _context.UserBook.Include(b => b.Book).Where(ub => ub.UserId == user.Id).ToListAsync();
            return View(userBooks);
        }

        //public async Task<IActionResult> Index(ApplicationUser User)
        //{
        //    //var applicationDbContext = _context.MovieActor.Include(m => m.Actor).Include(m => m.Movie); we can rework this for book later
        //    //return View(await applicationDbContext.ToListAsync()); change this for UserBook later
        //    //return _context.UserBook != null ?
        //    //            View(await _context.UserBook.ToListAsync()) :
        //    //            Problem("Entity set 'ApplicationDbContext.UserBook'  is null.");
        //    //return View();
        //    //var applicationDbContext = _context.UserBook.Include(m => m.Book).Include(m => m.User);

        //    var applicationDbContext = User.UserBooks;
        //    return View(applicationDbContext);
        //}

        // GET: UserBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserBook == null)
            {
                return NotFound();
            }

            var currUser = await _userManager.GetUserAsync(User);

            var userBook = await _context.UserBook
                .Include(ub => ub.User)
                .Include(ub => ub.Book)
                .FirstOrDefaultAsync(ub => ub.UserId == currUser.Id && ub.UserBookId == id); //(ub => ub.UserBookId == id);

            //var movieActor = await _context.MovieActor
            //   .Include(m => m.Actor)
            //   .Include(m => m.Movie)
            //   .FirstOrDefaultAsync(m => m.Id == id);

            if (userBook == null)
            {
                return NotFound();
            }

            return View(userBook);
        }

        // GET: UserBooks/Create
        public IActionResult Create()
        {

            // Get the current user
            var user = _userManager.GetUserAsync(User).Result;

            //var book = _context.Book.Find(bookId);

            // Create a new UserBook object
            var userBook = new UserBook { UserId = user.Id};

            ViewData["BookID"] = new SelectList(_context.Book, "Id", "Title");
            ViewData["UserID"] = new SelectList(_context.User, "Id", "FirstName");
            //ViewData["UserID"] = new SelectList(_context.User, "Id", "FirstName");

            // Add the UserBook object to the context and save changes
            //_context.UserBook.Add(userBook);
            //_context.SaveChanges();



            // Redirect back to the Books index page
            //return RedirectToAction("Index");

            return View(userBook);

        }

        // POST: UserBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, StartDate, EndDate, UserRating, UserReview, UserId, BookId")] UserBook userBook, int Id)
        {
            if (ModelState.IsValid)
            {
                //Just commented this out

                var user = await _userManager.GetUserAsync(User);



                        //.FirstOrDefaultAsync(m => m.Id == Id)
                
                //if (user == null)
                //{
                //    return NotFound();
                //};

                userBook.UserId = user.Id;
                //ViewData["BookID"] = new SelectList(_context.Book, "Id", "Title", userBook.BookId);
                //ViewData["UserID"] = new SelectList(_context.User, "Id", "FirstName", userBook.UserId);
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
            if (id == null)
            {
                return NotFound();
            }

            var userBook = await _context.UserBook.FindAsync(id);
            if (userBook == null)
            {
                return NotFound();
            }
            //return View(userBook);

            var user = await _userManager.GetUserAsync(User);
            if (user == null || userBook.UserId != user.Id)
            {
                return NotFound();
            }

            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title", userBook.BookId);
            return View(userBook);
        }

        // POST: UserBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, StartDate, EndDate, UserRating, UserReview")] UserBook userBook)
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
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title", userBook.BookId);
            return View(userBook);
        }

        // GET: UserBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserBook == null)
            {
                return NotFound();
            }

            var currUser = await _userManager.GetUserAsync(User);

            var userBook = await _context.UserBook
                .Include(ub => ub.User)
                .Include(ub => ub.Book)
                .FirstOrDefaultAsync(ub => ub.UserId == currUser.Id && ub.UserBookId == id); //(ub => ub.UserBookId == id);
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
