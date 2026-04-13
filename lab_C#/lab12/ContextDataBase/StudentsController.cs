using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab10_ASP.ContextDataBase;
using lab10_ASP.Tables;

namespace lab10_ASP.Controllers
{
    // Класс для привязки данных из appsettings.json
    public class SourceData
    {
        public string? MyName { get; set; }
        public string? MyGroup { get; set; }
        public string? MyUniversity { get; set; }
        public string? MyFaculty { get; set; }
    }

    public class StudentsController : Controller
    {
        private readonly UniversityDbDormanchukContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<StudentsController> _logger;

        // ИСПРАВЛЕННЫЙ конструктор
        public StudentsController(
            UniversityDbDormanchukContext context,
            IConfiguration configuration,
            ILogger<StudentsController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        // GET: Students
        public async Task<IActionResult> Index(string searchString, int? departmentFilter, string sortOrder)
        {
            // Получаем данные из appsettings.json
            var myOption = new SourceData();
            _configuration.GetSection("SourceData").Bind(myOption);

            _logger.LogInformation($"MyName: {myOption.MyName}");

            // Передаем данные в ViewBag
            ViewBag.MyName = myOption.MyName;
            ViewBag.MyGroup = myOption.MyGroup;
            ViewBag.MyUniversity = myOption.MyUniversity;
            ViewBag.MyFaculty = myOption.MyFaculty;

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentDepartmentFilter"] = departmentFilter;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["BirthSortParm"] = sortOrder == "birth" ? "birth_desc" : "birth";
            ViewData["CurrentSort"] = sortOrder;

            var students = _context.Студентыs
                .Include(s => s.КафедраNavigation)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s =>
                    (s.Фамилия != null && s.Фамилия.Contains(searchString)) ||
                    (s.Имя != null && s.Имя.Contains(searchString)) ||
                    (s.Отчество != null && s.Отчество.Contains(searchString)));
            }

            if (departmentFilter.HasValue && departmentFilter.Value > 0)
            {
                students = students.Where(s => s.Кафедра == departmentFilter.Value);
            }

            students = sortOrder switch
            {
                "name_desc" => students.OrderByDescending(s => s.Фамилия),
                "birth" => students.OrderBy(s => s.ГодРождения),
                "birth_desc" => students.OrderByDescending(s => s.ГодРождения),
                _ => students.OrderBy(s => s.Фамилия)
            };

            ViewBag.Departments = await _context.Кафедрыs.ToListAsync();

            return View(await students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Студентыs
                .Include(s => s.КафедраNavigation)
                .FirstOrDefaultAsync(m => m.КодСтудента == id);

            if (student == null) return NotFound();

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewBag.Departments = _context.Кафедрыs.ToList();
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Студенты student)
        {
            try
            {
                _logger.LogInformation($"Фамилия: {student.Фамилия}");
                _logger.LogInformation($"Имя: {student.Имя}");
                _logger.LogInformation($"Кафедра: {student.Кафедра}");

                _context.Студентыs.Add(student);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Ошибка: {ex.Message}";
                if (ex.InnerException != null)
                {
                    ViewBag.Error += $" | {ex.InnerException.Message}";
                }
                ViewBag.Departments = _context.Кафедрыs.ToList();
                return View(student);
            }
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Студентыs.FindAsync(id);
            if (student == null) return NotFound();

            ViewBag.Departments = _context.Кафедрыs.ToList();
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Студенты student)
        {
            if (id != student.КодСтудента) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.КодСтудента)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = _context.Кафедрыs.ToList();
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Студентыs
                .Include(s => s.КафедраNavigation)
                .FirstOrDefaultAsync(m => m.КодСтудента == id);

            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Студентыs.FindAsync(id);
            if (student != null)
            {
                _context.Студентыs.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Студентыs.Any(e => e.КодСтудента == id);
        }
    }
}