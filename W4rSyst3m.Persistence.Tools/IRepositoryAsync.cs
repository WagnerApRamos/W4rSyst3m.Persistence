#region Using

using System.Threading.Tasks;

#endregion

namespace W4rSyst3m.Persistence.Tools
{
    public interface IRepositoryAsync<T, K> :
        IReadOnlyRepositoryAsync<T, K>
        where T : class
    {
        /// <summary>
        /// Add a new entity into database
        /// </summary>
        /// <param name="entity">Instance of T</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Update a existing entity from database
        /// </summary>
        /// <param name="entity">Instance of T</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Delete a entity from database
        /// </summary>
        /// <param name="id">Key value</param>
        Task DeleteAsync(K id);

        /// <summary>
        /// Delete a entity from database
        /// </summary>
        /// <param name="entity">Instance Of T</param>
        Task DeleteAsync(T entity);
    }

    /// <summary>
    /// Interface to save and retrieve data from database
    /// </summary>
    /// <typeparam name="T">Have to be a class that represents a table</typeparam>
    public interface IRepositoryAsync<T> :
       IRepositoryAsync<T, int>
       where T : class
    { }
}
