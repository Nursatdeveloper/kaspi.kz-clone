
using Banking.Core.Entities;
using Banking.Infrastructure.Repositories.Base;
using System.Linq.Expressions;

namespace Banking.Infrastructure.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        
    }
}
