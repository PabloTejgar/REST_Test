using System.Linq.Expressions;

namespace REST_Test.Model.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(bool tracked = true);
        Task<T> GetAsync(int id, bool tracked = true);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        Task SaveAsync();
    }
}
