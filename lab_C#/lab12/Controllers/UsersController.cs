using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab10_ASP.Context;
using lab10_ASP.Models;

namespace lab10_ASP.Controllers
{
#pragma warning disable IDE0290 // Использовать основной конструктор
    public class UsersController : Controller
    {
        private readonly ContextDBApp _context;

        public UsersController(ContextDBApp context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users
                .Include(u => u.Role)
                .ToListAsync();
            return View(users);
        }
    }
#pragma warning restore IDE0290
}