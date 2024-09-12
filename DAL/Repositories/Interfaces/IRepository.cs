namespace DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        T Update(T entity);

        T Delete(int id);
    }
}