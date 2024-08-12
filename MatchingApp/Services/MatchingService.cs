using MatchingApp.Data;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;

namespace MatchingApp.Services
{
    public class MatchingService : IMatchingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatchingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllAsync(Filters filters)
        {
            var users = _unitOfWork.Repository<User>().GetAll();
            return users;
        }
    }
}
