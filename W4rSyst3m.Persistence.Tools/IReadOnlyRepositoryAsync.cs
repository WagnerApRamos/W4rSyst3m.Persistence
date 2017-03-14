#region Using

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

#endregion

namespace W4rSyst3m.Persistence.Tools
{
    public interface IReadOnlyRepositoryAsync<T, K>
        where T : class
    {
        /// <summary>
        /// Get a single instance of T
        /// </summary>
        /// <param name="id">value of key</param>
        /// <returns>Returns a instance of T</returns>
        Task<T> GetAsync(K id);

        /// <summary>
        /// Get a Single instance of T
        /// </summary>
        /// <param name="expression">Parameter to filter the query</param>
        /// <returns>Returns a instance of T</returns>
        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Get all data from database
        /// </summary>
        /// <returns>Returns a Collection of T</returns>
        Task<ICollection<T>> GetAllAsync();

        /// <summary>
        /// Get all data from database
        /// </summary>
        /// <param name="expression">Parameter to filter the query</param>
        /// <returns>Returns a Collection of T</returns>
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Counting records from database
        /// </summary>
        /// <returns>returns total records.</returns>
        Task<int> CountAsync();

        /// <summary>
        /// Counting records from database according with expression argument
        /// </summary>
        /// <param name="expression">Argument to filter the query</param>
        /// <returns>Returns total of records</returns>
        Task<int> CountAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Counting records from database
        /// </summary>
        /// <returns>returns total records.</returns>
        Task<long> LongCountAsync();

        /// <summary>
        /// Counting records from database according with expression argument
        /// </summary>
        /// <param name="expression">Argument to filter the query</param>
        /// <returns>Returns total of records</returns>
        Task<long> LongCountAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Verifies if there is any data in database
        /// </summary>
        /// <returns>Returns true if there is any data, otherwise returns false</returns>
        Task<bool> AnyAsync();

        /// <summary>
        /// Verifies if there is any data in database
        /// </summary>
        /// <param name="expression">Argument to filter the query</param>
        /// <returns>Returns true if there is any data, otherwise returns false</returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }

    /// <summary>
    /// Interface to Get information from database
    /// </summary>
    /// <typeparam name="T">Have to be a class that represents a table</typeparam>
    public interface IReadOnlyRepositoryAsync<T>
        : IReadOnlyRepositoryAsync<T, int>
        where T : class
    { }
}
