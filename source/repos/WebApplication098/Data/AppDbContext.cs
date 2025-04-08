using Microsoft.EntityFrameworkCore;
using WebApplication098.Models;

namespace WebApplication098.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define your tables here:
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Project> Projects { get; set; }



        public DbSet<TestPlan> Testplans { get; set; }

        public DbSet<TestSuite> Testsuites { get; set; }

        public DbSet<TestCase> TestCases { get; set; }

        public DbSet<TestStep> TestSteps { get; set; }



    }
}
