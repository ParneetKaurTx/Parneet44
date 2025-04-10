using WebApiApplication.Models;

namespace WebApiApplication.Repo.Contract
{
    public interface IEmployees
    {
        public ICollection<Employee> GetEmployee(); //To get admins from the database

        public Employee AddEmployee(Employee emp);
    }
}
