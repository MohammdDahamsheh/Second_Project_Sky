
namespace Applecation.Repository
{
    public interface IRepository<T>where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        bool UpdateAsync(T entity);

    }
}
