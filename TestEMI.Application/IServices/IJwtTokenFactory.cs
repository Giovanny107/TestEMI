using System.Security.Claims;

namespace TestEMI.Application.IServices
{
    public interface IJwtTokenFactory
    {
        string GenerateToken(string username, IEnumerable<Claim> claims);
    }
}
