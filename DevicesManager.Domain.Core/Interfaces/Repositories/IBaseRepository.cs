namespace DevicesManager.Domain.Core.Interfaces.Repositories
{
    /// <summary>
    /// Base repositories interface
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Add a new entity to the database
        /// </summary>
        /// <param name="obj">Entity to add</param>
        void Add(TEntity obj);

        /// <summary>
        /// Get entity by the identifier
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <returns>Entity (if found)</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Get all entities from the database
        /// </summary>
        /// <returns>A list of entities</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Update the entity properties on database
        /// </summary>
        /// <param name="obj">Entity new properties</param>
        void Update(TEntity obj);

        /// <summary>
        /// Delete an entity from the database
        /// </summary>
        /// <param name="obj">Entity to delete</param>
        void Delete(TEntity obj);

        /// <summary>
        /// Dispose the entity context changes
        /// </summary>
        void Dispose();
    }
}
