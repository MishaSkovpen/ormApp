using Microsoft.AspNetCore.Mvc;
using ormApp.Models;
using System.Linq;

namespace ormApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult Incomes()
        {
            var incomes = _context.Incomes.ToList();
            return View(incomes);
        }

        public IActionResult Expenses()
        {
            var expenses = _context.Expenses.ToList();
            return View(expenses);
        }
    }
}
