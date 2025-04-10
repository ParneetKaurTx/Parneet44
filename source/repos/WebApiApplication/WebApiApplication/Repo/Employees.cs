using System;
using WebApiApplication.Data;
using WebApiApplication.Models;
using WebApiApplication.Repo.Contract;

namespace WebApiApplication.Repo
{
    public class Employees:IEmployees
    {
        AppDbContext _context;

        public Employees(AppDbContext context)
        {
            _context = context;  //using this _context we can add and get data from database


        }


        public Employee AddEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return emp;
        }

        public ICollection<Employee> GetEmployee()
        {
            return _context.Employees.ToList();
        }
    }
}
