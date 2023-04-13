using Microsoft.AspNetCore.Mvc;

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
