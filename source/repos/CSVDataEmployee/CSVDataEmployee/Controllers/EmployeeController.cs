using CSVDataEmployee.Models;
using Microsoft.AspNetCore.Mvc;
using CSVDataEmployee.CSVHelper;

namespace CSVDataEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> employees = Helper.ReadEmployees();
            return View(employees);
           
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (employee == null)
            {
                TempData["ErrorMessage"] = "Invalid Employee Data!";
                return RedirectToAction("Add");
            }

            List<Employee> employees = Helper.ReadEmployees();

            // Auto-generate a unique ID
            employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;  //CHECK WHETHER EMPLOYEES LIsT HAS ANY DATA OR NOT
            //if employees.any() is empty then it will automaticaly asign it 1 otherwize it will find the max one and then increement by highest one
            employees.Add(employee);
            Helper.WriteEmployees(employees);

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            List<Employee> employees = Helper.ReadEmployees();

            // Find the employee to delete
            var employeeToRemove = employees.FirstOrDefault(e => e.Id == id);

            if (employeeToRemove == null)
            {
                TempData["ErrorMessage"] = "Employee not found!";
                return RedirectToAction("Index");
            }

            // Remove the employee from the list before passing it to the view
            employees.Remove(employeeToRemove);

            return View(employees); // Pass the updated list
        }



        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            List<Employee> employees = Helper.ReadEmployees() ?? new List<Employee>();

            var employeeToRemove = employees.FirstOrDefault(emp => emp.Id == id);
            if (employeeToRemove == null)
            {
                TempData["ErrorMessage"] = "Employee not found!";
                return RedirectToAction("Index");
            }

            employees.Remove(employeeToRemove);
            Helper.WriteEmployees(employees);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            List<Employee> employees = Helper.ReadEmployees();
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                TempData["ErrorMessage"] = "Employee not found!";
                return RedirectToAction("Index");
            }

            return View(employee); // Send employee data to the Update view
        }



        [HttpPost]
        public IActionResult Update(Employee updatedEmployee)
        {
            List<Employee> employees = Helper.ReadEmployees();
            var existingEmployee = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);

            if (existingEmployee == null)
            {
                TempData["ErrorMessage"] = "Employee not found!";
                return RedirectToAction("Index");
            }

            // Update employee details
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Position = updatedEmployee.Position;
            existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;
            existingEmployee.Email = updatedEmployee.Email;
            existingEmployee.Salary = updatedEmployee.Salary;

            Helper.WriteEmployees(employees); // Save updates

            return RedirectToAction("Index");
        }





    }
}
