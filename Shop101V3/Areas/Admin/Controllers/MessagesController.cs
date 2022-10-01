using Microsoft.AspNetCore.Mvc;
using Shop101V3.Models;
using Shop101V3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace Shop101V3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessagesController : Controller
    {

        private readonly AppDbContext db;
        public MessagesController(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<IActionResult> Index()
        {
            List<Message> messages = await db.Messages.ToListAsync();
            return View(messages);
        }


        public IActionResult Delete(int id)
        {
            Message message = db.Messages.FirstOrDefault(x => x.Id == id);
            if (message == null) return NotFound();
            return View(message);
        }


        public IActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.FirstOrDefault(x => x.Id == id);
            if (message == null) return NotFound();
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index", "Messages", new { area = "Admin" });
        }
    }
}
