namespace AdventureWorks.Interfaces
{
    /// <summary>
    /// Provides an inteface for managing entities.
    /// </summary>
    /// <typeparam name="T">The type of entity to manage.</typeparam>
    public interface IRepository<T>
    {
        // Retrieves a record by id.
        T Get(int id);

        // Retrieves all records in the entity.
        public List<T> GetAll();
    }

}
