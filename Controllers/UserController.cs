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
            var usersWithRoles = from user in _context.Users
                                 join userRole in _context.UserRoles on user.Id equals userRole.UserId
                                 join role in _context.Roles on userRole.RoleId equals role.Id
                                 select new
                                 {
                                     UserId = user.Id,
                                     Username = user.UserName,
                                     Email = user.Email,
                                     Role = role.Name
                                 };

            var applicationUsers = usersWithRoles.Select(u => new ApplicationUser
            {
                Id = u.UserId,
                UserName = u.Username,
                Email = u.Email,
                Role = u.Role
            }).ToList();

            return View(applicationUsers);
        }

        [HttpPost]
        [Authorize("Admin")]
        public IActionResult UpdateRole(string userId, string roleName)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound();
            }

            var role = _context.Roles.FirstOrDefault(r => r.Name == roleName);
            if (role == null)
            {
                return NotFound();
            }

            var userRoles = _context.UserRoles.Where(ur => ur.UserId == userId).ToList();
            foreach (var userRole in userRoles)
            {
                _context.UserRoles.Remove(userRole);
            }

            _context.UserRoles.Add(new IdentityUserRole<string> { UserId = userId, RoleId = role.Id });
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        //[Authorize("Admin")]
        //public IActionResult Index()
        //{
        //    var users = _context.Users.ToList();
        //    var applicationUsers = users.Select(u => new ApplicationUser { Id = u.Id, UserName = u.UserName, Email = u.Email }).ToList();
        //    return View(applicationUsers);
        //}
    }
}