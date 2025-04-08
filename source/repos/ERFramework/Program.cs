//STEP 1-ADD PACKAGES

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace ERFramework

//STEP-2- DESIGN ENTITIES(CLASS)
{
    DbOrganization dborganization = new DbOrganization();
    [Table("EmployeeTable")]

    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public decimal salary { get; set; }

    }
    
    //STEP 3
    //CREATE DBCONTEXT CLASS
    public class DbOrganization : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //step 4-add database conn string
            optionsBuilder.UseSqlServer("Server=DSCHD-PC-167\\NEWMSSQL;Database=Employee_Db;Trusted_Connection=True;TrustServerCertificate=True");

        }

        //STEP 5- MAKE DB SET(WHICH PERFORM ALL THE CRUD OPERATIONS AND MANY MORE IN THE ABLE IN WHICH WE WILL USE)
       public DbSet<Employee> EmpProp { get; set; } //WE WILL create an instance of DbOrgainzation class to perform the crud operations on TABLE WITH THE HELP OF PROPERTY(EMPLOYEESp)
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
