using Microsoft.AspNetCore.Mvc;

namespace EmployeeCSVapp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
