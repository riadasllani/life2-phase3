using MatchingApp.Data.Repository;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MatchingApp.Services
{
    public class MatchingService : IMatchingService
    {
        private readonly IGenericRepository<Match> _repository;
        private readonly IGenericRepository<User> _userRepository;

        public MatchingService(IGenericRepository<Match> repository, IGenericRepository<User> userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var data = await _userRepository.GetAllAsync();
            var GetUsersByCondition = data.GroupBy(x => x.Active)
                                           .OrderByDescending(g => g.Count())
                                           .Select(g => g.Key).ToList();

            return (IEnumerable<User>)GetUsersByCondition;
        }

        public async Task<Match> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Match matching)
        {
            await _repository.AddAsync(matching);
        }

        public async Task UpdateAsync(Match matching)
        {
            await _repository.UpdateAsync(matching);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task Match(bool like)
        {
            var data = await _repository.GetAllAsync();
            var hasLiked = data.GroupBy(x => x.UserLiked)
                                           .OrderByDescending(g => g.Count())
                                           .Select(g => g.Key);

            new JsonResult(hasLiked);
        }

        public async Task<JsonResult> SendMessage(int userId, Message message)
        {
            var data = await _repository.GetAllAsync();
            var matched = data.GroupBy(x => x.WasLikeMutual);
            
            return new JsonResult(matched);
        }
    }

}
