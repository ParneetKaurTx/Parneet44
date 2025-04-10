using System.ComponentModel.DataAnnotations;

namespace WebApiApplication.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Range(1000000000, 9999999999)]
        public string Phone { get; set; }

        [Required]
        public string Position { get; set; }
        [Required]

        public int Salary { get; set; }

    }
}
