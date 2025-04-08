using EmployeeCSVapp.Models;

namespace EmployeeCSVapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyDbContext myDbContext = new MyDbContext();
            myDbContext.Employees.ToList().Add(new Employee()
            {

            });
            foreach (var employee in myDbContext.Employees.ToList())
            {
                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Salary: {employee.Salary}");
            }
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
