using _521Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _521Final.Controllers
{
    public class ReccommendationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
