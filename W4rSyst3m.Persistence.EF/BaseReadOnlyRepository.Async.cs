#region Using

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

#endregion

namespace W4rSyst3m.Persistence.EF
{
    public partial class BaseReadOnlyRepository<T, K, C>
    {
        public async Task<bool> AnyAsync()
        {
            return await _dbSet.AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AnyAsync(expression);
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.CountAsync(expression);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstAsync(expression);
        }

        public async Task<T> GetAsync(K id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<long> LongCountAsync()
        {
            return await _dbSet.LongCountAsync();
        }

        public async Task<long> LongCountAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return await _dbSet.LongCountAsync(expression);
        }
    }
}
