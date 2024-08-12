using MatchingApp.Models.Entities;

namespace MatchingApp.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(string id);
        Task TopNActiveUsers();
        Task AverageCreditsByGenderAsync();
        Task YoungestOldestActiveUsersAsync();
        Task TotalCreditsByAgeGroup();
    }
}
