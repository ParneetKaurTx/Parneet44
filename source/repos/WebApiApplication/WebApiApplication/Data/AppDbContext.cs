using System.Collections.Generic;
using WebApiApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiApplication.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    //step 4-add database conn string
        //    optionsBuilder.UseSqlServer("Server=DSCHD-PC-167\\NEWMSSQL;Database=Employee_Db;Trusted_Connection=True;TrustServerCertificate=True");

        //}

        // Define your tables here:
        public DbSet<Employee> Employees { get; set; }
    }
}
