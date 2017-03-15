#region Using

using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using W4rSyst3m.Persistence.Tools;

#endregion

namespace W4rSyst3m.Persistence.EF
{
    public abstract class UnitOfWork<C> :
        IUnitOfWork,
        IDisposable
        where C : DbContext
    {
        private readonly C _dbContext;

        public UnitOfWork(C dbContext)
        {
            _dbContext = dbContext;
        }

        protected bool IsDisposed { get; set; }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (IsDisposed) return;

            _dbContext.Dispose();
            GC.SuppressFinalize(this);

            IsDisposed = true;

        }

        public void RollBack()
        {
            Parallel.ForEach(
                _dbContext.ChangeTracker.Entries().Where(c => c.State == EntityState.Added),
                (entity) => entity.State = EntityState.Detached);

            Parallel.ForEach(
                _dbContext.ChangeTracker.Entries().Where(c => c.State == EntityState.Deleted),
                (entity) => entity.State = EntityState.Unchanged);

            Parallel.ForEach(
                _dbContext.ChangeTracker.Entries().Where(c => c.State == EntityState.Modified),
                (entity) => {
                    entity.CurrentValues.SetValues(entity.OriginalValues);
                    entity.State = EntityState.Unchanged; });
        }

        public async Task RollBackAsync()
        {
            await Task.Run(() => RollBack());
        }
    }
}
