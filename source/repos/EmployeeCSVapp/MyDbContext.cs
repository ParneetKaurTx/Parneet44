using EmployeeCSVapp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCSVapp
{
    public class MyDbContext:DbContext
    {
        string conn = "Server=DSCHD-PC-167\\NEWMSSQL; Database=PariDb; Integrated Security=True; TrustServerCertificate=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conn);
            base.OnConfiguring(optionsBuilder);
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
