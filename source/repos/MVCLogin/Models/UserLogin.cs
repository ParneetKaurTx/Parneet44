using System.ComponentModel.DataAnnotations;

namespace MVCLogin.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage ="please enter valid details")]
        public string Username { get; set; }
        public string Password { get; set; }
        
    }
}
