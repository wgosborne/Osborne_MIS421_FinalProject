using Microsoft.AspNetCore.Mvc;

namespace _521Final.Controllers
{
    public class BrowseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
