using TestEMI.Application.DTO_s;
using TestEMI.Core.Models;

namespace TestEMI.Application.IServices
{
    public interface IUserService
    {
        Task<User> CreateUser(RegisterUser user);

        Task<User?> GetUserByUserName(string userName);
    }
}
