using _521Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _521Final.Controllers
{
    public class GenresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
