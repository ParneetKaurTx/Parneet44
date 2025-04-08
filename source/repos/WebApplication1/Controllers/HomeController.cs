using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    // Use a static list to persist data during runtime (for testing)
    private static List<User> users = new List<User>
    {
        new User { Name = "Anshuman", ContactNo = 765436288 },
        new User { Name = "Sanvy", ContactNo = 987654356 },
        new User { Name = "Parneet Kaur", ContactNo = 999473522 },
    };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    // GET: Create (Displays the form and user list)
    public IActionResult Create()
    {
        return View(new List<User>()); // Pass a list to the view
    }

    // POST: Create (Handles form submission)
    [HttpPost]
    public IActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            users.Add(user); // Add the new user to the list
            return View(users); // Return the updated list
        }

        return View(); // Always return a list to prevent errors
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
