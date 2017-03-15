#region Using

using System.Data.Entity;
using W4rSyst3m.Persistence.Tools;

#endregion

namespace W4rSyst3m.Persistence.EF
{
    public abstract class BaseRepository<T, K, C> :
        BaseReadOnlyRepository<T, K, C>,
        IRepository<T, K>
        where T : class
        where C : DbContext
    {
        private readonly C _dbContext;
        public BaseRepository(
            C dbContext)
            : base(dbContext)
        { }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(K id)
        {
            var entity = Get(id);
            Delete(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }

    public abstract class BaseRepository<T, C> :
        BaseRepository<T, int, C>,
        IRepository<T>
        where T : class
        where C : DbContext
    {
        public BaseRepository(
            C dbContext) 
            : base(dbContext)
        { }
    }
}