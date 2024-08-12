using MatchingApp.Models.Entities;

namespace MatchingApp.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<IEnumerable<User>> GetTopUsersAsync(int page, int pageSize);
        Task<IEnumerable<User>> GetYoungAndOldUsersAsync(int page, int pageSize);
        

    }
}
