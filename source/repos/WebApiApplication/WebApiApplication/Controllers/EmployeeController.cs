using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApplication.Models;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);



            }
            return Ok(employee);
        }


        //remove i have to
        [HttpPost]
        [Authorize] // <-- Requires JWT token
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _Employees.AddEmployee(employee);
            return Ok(result);
        }
    }
}
