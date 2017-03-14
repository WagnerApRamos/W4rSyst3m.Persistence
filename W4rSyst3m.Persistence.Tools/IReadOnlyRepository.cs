#region Using

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

#endregion

namespace W4rSyst3m.Persistence.Tools
{
    /// <summary>
    /// Interface to retrieve information from database
    /// </summary>
    /// <typeparam name="T">Have to be a class that represents a table</typeparam>
    /// <typeparam name="K">Type of Id (int, string, etc)</typeparam>
    public interface IReadOnlyRepository<T, K>
        where T : class
    {
        /// <summary>
        /// Get a single instance of T
        /// </summary>
        /// <param name="id">value of key</param>
        /// <returns>Returns a instance of T</returns>
        T Get(K id);

        /// <summary>
        /// Get a Single instance of T
        /// </summary>
        /// <param name="expression">Parameter to filter the query</param>
        /// <returns>Returns a instance of T</returns>
        T Get(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Get all data from database
        /// </summary>
        /// <returns>Returns a Collection of T</returns>
        ICollection<T> GetAll();

        /// <summary>
        /// Get all data from database
        /// </summary>
        /// <param name="expression">Parameter to filter the query</param>
        /// <returns>Returns a Collection of T</returns>
        ICollection<T> GetAll(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Counting records from database
        /// </summary>
        /// <returns>returns total records.</returns>
        int Count();

        /// <summary>
        /// Counting records from database according with expression argument
        /// </summary>
        /// <param name="expression">Argument to filter the query</param>
        /// <returns>Returns total of records</returns>
        int Count(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Counting records from database
        /// </summary>
        /// <returns>returns total records.</returns>
        long LongCount();

        /// <summary>
        /// Counting records from database according with expression argument
        /// </summary>
        /// <param name="expression">Argument to filter the query</param>
        /// <returns>Returns total of records</returns>
        long LongCount(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Verifies if there is any data in database
        /// </summary>
        /// <returns>Returns true if there is any data, otherwise returns false</returns>
        bool Any();

        /// <summary>
        /// Verifies if there is any data in database
        /// </summary>
        /// <param name="expression">Argument to filter the query</param>
        /// <returns>Returns true if there is any data, otherwise returns false</returns>
        bool Any(Expression<Func<T, bool>> expression);
    }

    /// <summary>
    /// Interface to Get information from database
    /// </summary>
    /// <typeparam name="T">Have to be a class that represents a table</typeparam>
    public interface IReadOnlyRepository<T> 
        : IReadOnlyRepository<T, int>
        where T : class
    { }
}
