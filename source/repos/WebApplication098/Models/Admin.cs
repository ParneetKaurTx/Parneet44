using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication098.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [EmailAddress]
        public string email { get; set; }

        [ForeignKey("Organization"), Required]
        public int Organization_id { get; set; }

        public Organization OrganizationInfo { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.")]
        public string Password { get; set; }
    }

    [Table("Organizations")]
    public class Organization
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int created_by { get; set; }

        public ICollection<Project> Projects { get; set; }
    }

    [Table("Project")]
    public class Project
    {
        [Key]
        [Required]
        public int project_id { get; set; }

        [Required]
        public string project_name { get; set; }

        [Required]
        public string status { get; set; }

        [Required]
        [MaxLength(500)]
        public string description { get; set; }

        [Required]
        public DateTime startDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [ForeignKey("Organization"), Required]
        public int Organization_id { get; set; }

        public Organization OrganizationInfo { get; set; }

        public ICollection<TestPlan> TestPlans { get; set; }
    }

    [Table("TestPlan")]
    public class TestPlan
    {
        [Key]
        [Required]
        public int TestPlan_id { get; set; }

        [Required]
        [MaxLength(10)]
        public string name { get; set; }

        [Required]
        [MaxLength(500)]
        public string objective { get; set; }

        [Required]
        public string created_by { get; set; }

        [Required]
        public string strategy { get; set; }

        [ForeignKey("Project")]
        public int project_id { get; set; }

        public Project project_info { get; set; }

        public ICollection<TestSuite> TestSuites { get; set; }
    }

    [Table("TestSuite")]
    public class TestSuite
    {
        [Key]
        [Required]
        public int testSuite_id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [MaxLength(500)]
        public string description { get; set; }

        [ForeignKey("TestPlan")]
        public int TestPlanId { get; set; }

        public TestPlan TestPlan { get; set; }

        public ICollection<TestCase> TestCases { get; set; }
    }

    [Table("TestCases")]
    public class TestCase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string description { get; set; }

        [Required]
        public string steps { get; set; }

        public bool IsAutomated { get; set; } = false;

        [ForeignKey("TestSuite")]
        public int TestSuite_id { get; set; }

        public TestSuite TestSuite_info { get; set; }

        public ICollection<TestStep> TestSteps { get; set; }
    }

    [Table("TestSteps")]
    public class TestStep
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string action { get; set; }

        [Required]
        public string ExpectedResult { get; set; }

        [Required]
        public string actualResult { get; set; }

        [ForeignKey("TestCase")]
        public int TestCase_id { get; set; }

        public TestCase testCase_info { get; set; }
    }
}
