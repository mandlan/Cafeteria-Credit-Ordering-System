using Cafeteria_Credit___Ordering_System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Cafeteria_Credit___Ordering_System.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public OrdersController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;

            _context = context;
           
        }

        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> MyOrders()
        {
            var userId = _userManager.GetUserId(User);
            var employee = await _context.Employees
                .Include(e => e.Orders)
                .FirstOrDefaultAsync(e => e.IdentityUserId == userId);

            if (employee == null) return NotFound();

            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.EmployeeId == employee.Id)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(orders);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int orderId, string newStatus)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.Status = newStatus;
                if (newStatus == "Delivering")
                {
                    order.EstimatedDeliveryTime = DateTime.Now.AddMinutes(25);
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("AdminOrders");
        }

    }
}
