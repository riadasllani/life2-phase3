using MatchingApp.Data;
using MatchingApp.Models.Entities;

namespace MatchingApp.Services
{
    public class MatchingService : IMatchingService
    {

        private readonly IGenericRepository<Match> _repository;

        public MatchingService(IGenericRepository<Match> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Match>> GetUsers(int pageNumber, int pageSize)
        {
            return await _repository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task AddAsync(Match matchingData)
        {
            await _repository.AddAsync(matchingData);
        }

    }
}
