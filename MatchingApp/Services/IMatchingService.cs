using MatchingApp.Models.Entities;

namespace MatchingApp.Services
{
    public interface IMatchingService
    {
        Task<IEnumerable<Match>> GetUsers(int pageNumber, int pageSize);
        Task AddAsync(Match matchingData);

    }
}
