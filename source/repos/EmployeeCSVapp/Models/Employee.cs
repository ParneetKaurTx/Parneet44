using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace EmployeeCSVapp.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string Position { get; set; } = "Trainee";
        [Required]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        [EmailAddress,Required]
        public string? Email { get; set; }

        [Required]
        public int Salary { get; set; } = 0;

    }
}

