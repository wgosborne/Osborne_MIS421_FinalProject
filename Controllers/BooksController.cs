using Microsoft.AspNetCore.Mvc;
using _521Final.Models;
using System.Diagnostics;

namespace _521Final.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
