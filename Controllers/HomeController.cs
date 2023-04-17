using _521Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _521Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _chatGPTClient = new ChatGPTClient("your-api-key-here");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //ChatGPT functionality, we need to add the api key to the constructor at the top
        private readonly ChatGPTClient _chatGPTClient;

        [HttpPost]
        public ActionResult GetChatResponse(string message)
        {
            var response = _chatGPTClient.GetChatResponse(message);
            return Content(response);
        }
    }
}