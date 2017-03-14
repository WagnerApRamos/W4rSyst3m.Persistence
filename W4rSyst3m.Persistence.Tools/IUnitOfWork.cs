#region Using

using System.Threading.Tasks;

#endregion

namespace W4rSyst3m.Persistence.Tools
{
    /// <summary>
    /// Interface to Unit of Work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commit all changes of a database context
        /// </summary>
        void Commit();

        /// <summary>
        /// Commit all changes of a database context asyncronously
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Undo all changes of a database context
        /// </summary>
        void RollBack();

        /// <summary>
        /// Undo all changes of a database context asyncronously
        /// </summary>
        Task RollBackAsync();
    }
}
