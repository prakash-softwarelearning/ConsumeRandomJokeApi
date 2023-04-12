using ConsumeRandomJokeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;

namespace ConsumeRandomJokeApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService _service;

        public HomeController(ILogger<HomeController> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var jokes = await _service.GetRandomJokes();
            ViewBag.Jokes = await _service.GetJokeCount();
            return View(jokes);
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
    }
}