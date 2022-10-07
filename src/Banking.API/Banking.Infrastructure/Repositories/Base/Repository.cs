using Banking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                var createdEntity = await _context.Set<T>().AddAsync(entity);
                if(createdEntity.Entity is not null)
                {
                    await _context.SaveChangesAsync();
                }
                return createdEntity.Entity;
            }
            catch (Exception ex)
            {
                // Need to use Logger!
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exist(Expression<Func<T, bool>> condition)
        {
            var entity = await _context.Set<T>().Where(condition).FirstOrDefaultAsync();
            if(entity is null)
            {
                return false;
            }
            return true;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
