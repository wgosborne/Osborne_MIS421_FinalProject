using Microsoft.AspNetCore.Mvc;

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
