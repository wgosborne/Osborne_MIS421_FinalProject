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
    }
}