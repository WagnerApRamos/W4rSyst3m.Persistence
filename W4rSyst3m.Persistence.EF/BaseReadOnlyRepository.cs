#region Using

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using W4rSyst3m.Persistence.Tools;
using W4rSyst3m.Tools.Utilities;

#endregion

namespace W4rSyst3m.Persistence.EF
{
    public class BaseReadOnlyRepository<T, K, C> :
        IReadOnlyRepository<T, K>
        where T : class
        where C : DbContext
    {
        protected readonly DbSet<T> _dbSet;

        public BaseReadOnlyRepository(C dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public bool Any()
        {
            return _dbSet.Any();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Any(expression);
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Count(expression);
        }

        public long LongCount()
        {
            return _dbSet.LongCount();
        }

        public long LongCount(Expression<Func<T, bool>> expression)
        {
            return _dbSet.LongCount(expression);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);

        }

        public T Get(K id)
        {
            var entity = _dbSet.Find(id);

            if (entity.IsNull()) throw new PersistenceException("{0} has not found".FormatAs(id));

            return entity;
        }

        public ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public ICollection<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }
    }

    public class BaseReadOnlyRepository<T, C> :
        BaseReadOnlyRepository<T, int, C>,
        IReadOnlyRepository<T>
        where T : class
        where C : DbContext
    {
        public BaseReadOnlyRepository(
            C dbContext) 
            : base(dbContext)
        { }
    }
}
