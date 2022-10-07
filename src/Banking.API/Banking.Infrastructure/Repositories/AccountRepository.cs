using Banking.Core.Entities;
using Banking.Infrastructure.Data;
using Banking.Infrastructure.Repositories.Base;

namespace Banking.Infrastructure.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
