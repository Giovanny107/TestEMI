using TestEMI.Core.Models;

namespace TestEMI.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);

        Task<User?> GetUserByUserName(string userName);
    }
}
