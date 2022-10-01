using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop101V3.DAL;
using Shop101V3.Models;
using Shop101V3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101v2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext db;
        public ProductsController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Filter(int? subcategoryId, int? categoryId, string query)
        {
             FilterViewModel fvm = new FilterViewModel();
            if (subcategoryId != null) fvm.products = await db.Products.Include(x=>x.SubCategory).Where(x => x.SubCategoryId == subcategoryId).ToListAsync();
            else if (categoryId != null) fvm.products = await db.Products.Include(x => x.SubCategory).Where(x => x.SubCategory.CategoryId == categoryId).ToListAsync();
            else fvm.products = await db.Products.Include(x => x.SubCategory).ToListAsync();

            if (!string.IsNullOrEmpty(query)) fvm.products = fvm.products.Where(x => x.Name.ToLower().Contains(query.ToLower())).ToList();
            return View(fvm);
        }


        public async Task<IActionResult> Details(int id)
        {
            Product product = await db.Products.Include(x => x.SubCategory.Category).Include(x=>x.ProductImages).FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return RedirectToAction("Index", "Home");
            return View(product);
        }
    }
}
