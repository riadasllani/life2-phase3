using MatchingApp.Models.Entities;

namespace MatchingApp.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize);
        Task AddAsync(T entity);
    }

}
