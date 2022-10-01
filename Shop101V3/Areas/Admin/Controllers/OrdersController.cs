using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop101V3.DAL;
using Shop101V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101V3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly AppDbContext db;
        public OrdersController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Product).OrderByDescending(x => x.Id).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null) return NotFound();
            return View(order);
        }
        public IActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null) return NotFound();
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Order order = db.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null) return NotFound();

            return View(order);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (!ModelState.IsValid) return View();
            db.Update(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
