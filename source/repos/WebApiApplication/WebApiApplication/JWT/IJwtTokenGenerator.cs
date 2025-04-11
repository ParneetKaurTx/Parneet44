using WebApiApplication.Models;

namespace WebApiApplication.JWT
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(Employee applicationUser);
    }
}
