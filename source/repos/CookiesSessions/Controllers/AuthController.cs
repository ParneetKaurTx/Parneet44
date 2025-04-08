using CookiesSessions.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookiesSessions.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AuthModel u)
        {
            if (ModelState.IsValid == true)
            {
                HttpContext.Response.Cookies.Append("CookieName", u.Username);
                HttpContext.Response.Cookies.Append("CookiePassword", u.Password);
                return RedirectToAction("Index","Home");
            }

            return View();

        }
    }
}
