using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cafeteria_Credit___Ordering_System.Data;
using Cafeteria_Credit___Ordering_System.Models;
using Cafeteria_Credit___Ordering_System.ViewModels;    

namespace Cafeteria_Credit___Ordering_System.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeNumber,Name,balance,lastDepositMonth")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeNumber,Name,balance,lastDepositMonth")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
        [HttpGet]
        public IActionResult Deposit() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deposit(DepositViewModel model)
        {
            if (!ModelState.IsValid || model.DepositAmount <= 0)
            {
                ModelState.AddModelError("", "Enter a valid deposit amount.");
                return View(model);
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeNumber == model.EmployeeNumber);

            if (employee == null)
            {
                ModelState.AddModelError("", "Employee not found.");
                return View(model);
            }

            var currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            // Reset deposit tracking if it's a new month
            if (employee.lastDepositMonth != currentMonth)
            {
                employee.lastDepositMonth = currentMonth;
                employee.MonthlyDeposit = 0; 
            }

            // Calculate bonus based on R250 increments
            decimal previousTotal = employee.MonthlyDeposit;
            decimal newTotal = previousTotal + model.DepositAmount;
            int prevBlocks = (int)(previousTotal / 250);
            int newBlocks = (int)(newTotal / 250);
            int earnedBlocks = newBlocks - prevBlocks;

            decimal bonus = earnedBlocks * 500;

            employee.balance += model.DepositAmount + bonus;
            employee.MonthlyDeposit = newTotal;

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = employee.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(PlaceOrderViewModel model)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNumber == model.EmployeeNumber);
            if (employee == null || model.MenuItems == null)
            {
                ModelState.AddModelError("", "Employee or items not found.");
                return View(model);
            }

            var totalCost = model.MenuItems.Sum(i => i.Price * i.Quantity);
            if (employee.balance < totalCost)
            {
                ModelState.AddModelError("", "Insufficient funds.");
                return View(model);
            }

            // Create Order
            var order = new Order
            {
                EmployeeId = employee.Id.ToString(),
                OrderDate = DateTime.Now,
                TotalAmount = totalCost,
                Status = "Pending"
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(); 

            // Add OrderItems
            foreach (var item in model.MenuItems.Where(i => i.Quantity > 0))
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    MenuItemId = item.MenuItemId,
                    Quantity = item.Quantity,
                    Price = item.Price
                };
                _context.OrderItems.Add(orderItem);
            }

            employee.balance -= totalCost;
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = employee.Id });
        }
    }
}
