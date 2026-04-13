using Microsoft.AspNetCore.Mvc;
using lab10_ASP.Context;

namespace lab10_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContextDBApp _context;

        public HomeController(ILogger<HomeController> logger, ContextDBApp context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}