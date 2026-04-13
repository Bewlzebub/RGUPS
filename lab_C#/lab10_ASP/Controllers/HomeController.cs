using lab10_ASP.ContextDataBase;
using lab10_ASP.Models;
using lab10_ASP.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace lab10_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UniversityDbDormanchukContext _context;

        public HomeController(ILogger<HomeController> logger, UniversityDbDormanchukContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Присоединяем таблицу Кафедры через внешний ключ (JOIN)
            var students = _context.Студентыs
                .Include(x => x.КафедраNavigation)  // Загружаем связанную кафедру
                .ToList();

            return View(students);
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