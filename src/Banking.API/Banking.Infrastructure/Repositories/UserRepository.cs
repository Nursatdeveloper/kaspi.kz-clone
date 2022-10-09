using Banking.Core.Entities;
using Banking.Infrastructure.Data;
using Banking.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            User user = await _context.Users.Include(a => a.Accounts).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}
