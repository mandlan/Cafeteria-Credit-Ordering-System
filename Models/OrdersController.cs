using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cafeteria_Credit___Ordering_System.Data;
using Cafeteria_Credit___Ordering_System.Models;

namespace Cafeteria_Credit___Ordering_System.Models
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AdminOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.Employee)
                .Where(o => o.Status != "Delivered")
                .OrderBy(o => o.OrderDate)
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
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("AdminOrders");
        }

    }
}
