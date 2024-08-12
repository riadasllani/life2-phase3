using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;

namespace MatchingApp.Services
{
    public interface IMatchingService
    {
        Task<IEnumerable<User>> GetAllAsync(Filters filters);
        
    }
}
