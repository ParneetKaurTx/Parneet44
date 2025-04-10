using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApplication.Repo.Contract;

namespace WebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployees _Employees;
        public EmployeeController(IEmployees Employees)
        {
            _Employees = Employees;


        }

        [HttpGet]
        public IActionResult GetEmployee()
        {
            var employee = _Employees.GetEmployee();
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);



            }
            return Ok(employee);
        }
    }
}
