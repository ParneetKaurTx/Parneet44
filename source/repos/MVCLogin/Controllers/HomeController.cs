using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCLogin.Models;

namespace MVCLogin.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(UserLogin u)
    {
        if (ModelState.IsValid == true)
        {
            CookieOptions cookie = new CookieOptions();

            HttpContext.Response.Cookies.Append("cookieName", u.Username);
            HttpContext.Response.Cookies.Append("cookiePassword", u.Password);
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    
}
