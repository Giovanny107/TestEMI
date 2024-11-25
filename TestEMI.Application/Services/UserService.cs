using TestEMI.Application.DTO_s;
using TestEMI.Application.IServices;
using TestEMI.Core.Interfaces;
using TestEMI.Core.Models;

namespace TestEMI.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(RegisterUser user)
        {
            return await _userRepository.CreateUser(user.ConvertUserToDomain());
        }

        public Task<User?> GetUserByUserName(string userName)
        {
            return _userRepository.GetUserByUserName(userName);
        }
    }
}
