#region Using

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

#endregion

namespace W4rSyst3m.Persistence.EF
{
    /// <summary>
    /// Custom implementation of Dbcontext
    /// </summary>
    /// <typeparam name="C"></typeparam>
    public abstract class MyDbContext<C> :
        DbContext
        where C : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public MyDbContext(string nameOrConnectionString = null)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<C>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add<PluralizingTableNameConvention>();
            SettingEntities(modelBuilder);
        }

        /// <summary>
        /// Setting the models using DbModelBuilder
        /// </summary>
        /// <param name="modelBuilder">Database Model builder</param>
        protected virtual void SettingEntities(DbModelBuilder modelBuilder)
        { }
    }
}
