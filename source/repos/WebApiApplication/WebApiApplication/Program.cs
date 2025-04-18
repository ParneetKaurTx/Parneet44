using WebApiApplication.Repo.Contract;
using WebApiApplication.Repo;
using Microsoft.EntityFrameworkCore;
using WebApiApplication.Data;
using Microsoft.Extensions.Configuration;
using WebApiApplication.JWT;
using WebApiApplication.DTO;

var builder = WebApplication.CreateBuilder(args);
// Register AppDbContext with Dependency Injection for runtime
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IEmployees, Employees>();

//remove i have to
builder.Services.Configure<JwtOptions>(configuration.GetSection("ApiSettings:JwtOptions"));
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
