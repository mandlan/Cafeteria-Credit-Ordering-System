using Cafeteria_Credit___Ordering_System.Data;
using Cafeteria_Credit___Ordering_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_Credit___Ordering_System.Controllers
{

    public class DashboardController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public DashboardController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var userRoles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(userId));

            var viewModel = new DashboardViewModel();

            if (userRoles.Contains("Employee"))
            {
                var employee = await _context.Employees
                    .Include(e => e.Orders)
                    .FirstOrDefaultAsync(e => e.IdentityUserId == userId);

                viewModel.EmployeeName = employee.Name;
                viewModel.Balance = employee.balance;
                viewModel.RecentOrders = employee.Orders
                    .OrderByDescending(o => o.OrderDate)
                    .Take(3)
                    .ToList();
            }
            else if (userRoles.Contains("Admin"))
            {
                viewModel.TotalEmployees = await _context.Employees.CountAsync();
                viewModel.PendingOrders =  _context.Orders
                    .Where(o => o.Status == "Pending")
                    .OrderByDescending(o => o.OrderDate)
                    .Take(5)
                    .ToList();
            }

            return View(viewModel);
        }
    }
}
