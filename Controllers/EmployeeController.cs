using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cafeteria_Credit___Ordering_System.Data;
using Cafeteria_Credit___Ordering_System.Models;

namespace Cafeteria_Credit___Ordering_System.Controllers
{
    public class EmployeeController: Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
        }
        // GET: list of employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }
        // GET: Restaurant

        public IActionResult Create()
        {
            return View();
        }

        // GET: Create a new employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Employee employee)
        {
            if (ModelState.IsValid)
            {
                {
                    // Initialize properties here
                };
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        //GET: Get employee by id
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
    }
}
