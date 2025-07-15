using Cafeteria_Credit___Ordering_System.Data;
using Cafeteria_Credit___Ordering_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_Credit___Ordering_System.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Restaurant
        public async Task<IActionResult> Index()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            return View(restaurants);
        }

        // GET: Restaurant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(restaurant);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurant/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }
    }
}
