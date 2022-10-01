using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop101V3.DAL;
using Shop101V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101V3.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext db;
        public BasketController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult AddToBasket(int? id)
        {
            if (id == null) return NotFound();
            Product product = db.Products.Find(id);
            if (product == null) return NotFound();

            List<BasketItemVM> basket;

            if (Request.Cookies["basket"] == null)
            {
                basket = new List<BasketItemVM>();
            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketItemVM>>(Request.Cookies["basket"]);
            }
            BasketItemVM existingBasketItem = basket.FirstOrDefault(x => x.ProductId == product.Id);
            if (existingBasketItem == null)
            {
                BasketItemVM basketItem = new BasketItemVM();
                basketItem.Name = product.Name;
                basketItem.ProductId = product.Id;
                basketItem.Price = product.Price;
                basketItem.MainImage = product.MainImage;
                basketItem.Count = 1;

                basket.Add(basketItem);
            }
            else
            {
                existingBasketItem.Count++;
            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket), new CookieOptions() { MaxAge = TimeSpan.FromDays(14) });

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            if (Request.Cookies["basket"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<BasketItemVM> basket = JsonConvert.DeserializeObject<List<BasketItemVM>>(Request.Cookies["basket"]);
            double total = 0;

            foreach (BasketItemVM item in basket)
            {
                total = item.Price * item.Count;
            }
            ViewBag.Total = total;
            return View(basket);
        }
        public IActionResult RemoveFromBasket(int? id)
        {
            if (id == null) return NotFound();

            List<BasketItemVM> basket;
            if (Request.Cookies["basket"] == null)
            {
                basket = new List<BasketItemVM>();
            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketItemVM>>(Request.Cookies["basket"]);
            }
            BasketItemVM existingBasketItem = basket.FirstOrDefault(x => x.ProductId == id);

            if (existingBasketItem == null)
            {
                return RedirectToAction("Index");
            }
            else if (existingBasketItem.Count > 1)
            {
                existingBasketItem.Count--;
            }
            else
            {
                basket.Remove(existingBasketItem);
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket), new CookieOptions() { MaxAge = TimeSpan.FromDays(14) });

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Confirm(string email, string address)
        {
            Order order = new Order()
            {
                Email = email,
                Address = address
            };
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();

            List<BasketItemVM> basket = JsonConvert.DeserializeObject<List<BasketItemVM>>(Request.Cookies["basket"]);

            foreach (BasketItemVM item in basket)
            {
                OrderItem orderItem = new()
                {
                    ProductId = item.ProductId,
                    OrderId = order.Id,
                    Count = item.Count
                };
                await db.OrderItems.AddAsync(orderItem);
            }
            await db.SaveChangesAsync();

            Response.Cookies.Delete("basket");
            return RedirectToAction("Index", "Home");
        }
    }
}
