using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop101V3.Controllers
{
    public class TestController : Controller
    {
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("name", "Ali");
            Response.Cookies.Append("car", "f10", new CookieOptions(){ MaxAge = TimeSpan.FromDays(1) });
            return Content("okay");
        }
        public IActionResult GetSession()
        {
            string val = HttpContext.Session.GetString("name");
            return Content(val);
        }
    }
}
