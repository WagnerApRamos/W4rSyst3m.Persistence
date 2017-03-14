namespace W4rSyst3m.Persistence.Tools
{
    /// <summary>
    /// Interface to save and retrieve data from database
    /// </summary>
    /// <typeparam name="T">Have to be a class that represents a table</typeparam>
    /// <typeparam name="K">Type of Id (int, string, etc)</typeparam>
    public interface IRepository<T, K> :
        IReadOnlyRepository<T, K>
        where T : class
    {
        /// <summary>
        /// Add a new entity into database
        /// </summary>
        /// <param name="entity">Instance of T</param>
        void Add(T entity);

        /// <summary>
        /// Update a existing entity from database
        /// </summary>
        /// <param name="entity">Instance of T</param>
        void Update(T entity);

        /// <summary>
        /// Delete a entity from database
        /// </summary>
        /// <param name="id">Key value</param>
        void Delete(K id);

        /// <summary>
        /// Delete a entity from database
        /// </summary>
        /// <param name="entity">Instance Of T</param>
        void Delete(T entity);
    }

    /// <summary>
    /// Interface to save and retrieve data from database
    /// </summary>
    /// <typeparam name="T">Have to be a class that represents a table</typeparam>
    public interface IRepository<T> :
       IRepository<T, int>
       where T : class
    { }
}
