using _521Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _521Final.Controllers
{
    public class BrowseController : Controller
    {
        private readonly ILogger<BrowseController> _logger;

        public BrowseController(ILogger<BrowseController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
