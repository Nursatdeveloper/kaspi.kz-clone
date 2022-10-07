using Banking.Core.Entities;
using Banking.Infrastructure.Data;
using Banking.Infrastructure.Repositories.Base;

namespace Banking.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
