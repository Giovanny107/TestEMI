using Microsoft.EntityFrameworkCore;
using TestEMI.Core.Interfaces;
using TestEMI.Core.Models;
using TestEMI.Infrastructure.Data;

namespace TestEMI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EmployeeContext _context;

        public UserRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetUserByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == userName);
        }
    }
}
