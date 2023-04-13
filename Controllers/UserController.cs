using Microsoft.AspNetCore.Mvc;

namespace _521Final.Controllers
{
    public class UserController : Controller
    {
        public IActionResult MyBooks()
        {
            return View();
        }
    }
}
