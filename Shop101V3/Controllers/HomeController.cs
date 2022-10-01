using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop101V3.DAL;
using Shop101V3.Models;
using Shop101V3.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101v2.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext db;
        public HomeController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            IndexViewModel hvm = new IndexViewModel()
            {
                Categories = await db.Categories.Include(x => x.SubCategories).ToListAsync(),
            };
            return View(hvm);
        }
        public IActionResult Contact()
        {
            return View();
        }
        public async Task<IActionResult> SendMessage(Message msg)
        {
            if (ModelState.IsValid)
            {
                msg.Date = DateTime.Now;
                await db.Messages.AddAsync(msg);
                await db.SaveChangesAsync();
                TempData["result"] = "Message Sent.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["result"] = "Message was not Send.";
                return RedirectToAction("Index");
            }
        }
    }
}
