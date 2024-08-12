using MatchingApp.Data.Repository;
using MatchingApp.Models.Entities;

namespace MatchingApp.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;

        public UserService(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await _repository.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _repository.UpdateAsync(user);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task TopNActiveUsers()
        {

        }
        public async Task AverageCreditsByGenderAsync()
        {

        }
        public async Task YoungestOldestActiveUsersAsync()
        {

        }
        public async Task TotalCreditsByAgeGroup()
        {

        }
    }

}
