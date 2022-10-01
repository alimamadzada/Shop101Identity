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
    public class CategoriesController : Controller
    {
        private readonly AppDbContext db;
        public CategoriesController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await db.Categories.ToListAsync();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Category category = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) return RedirectToAction("Index");
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (!CategoryExists(category.Id)) return View(category);

            if (!ModelState.IsValid)
            {
                return View();
            }
            db.Categories.Update(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }


        public IActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null) return NotFound();
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        private bool CategoryExists(int id)
        {
            return db.Categories.Any(x => x.Id == id);
        }
    }
}
