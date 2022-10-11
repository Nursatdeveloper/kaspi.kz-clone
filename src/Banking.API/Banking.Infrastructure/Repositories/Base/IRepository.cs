using System.Linq.Expressions;

namespace Banking.Infrastructure.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> condition);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> condition);
        bool Update(T entity);
        Task<bool> Delete(int id);
        Task<bool> Exist(Expression<Func<T, bool>> condition);
    }
}
