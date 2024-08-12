using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MatchingApp.Services
{
    public interface IMatchingService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<Match> GetByIdAsync(string id);
        Task AddAsync(Match match);
        Task UpdateAsync(Match match);
        Task DeleteAsync(string id);
        Task Match(bool like);
        Task<JsonResult> SendMessage(int userId, Message message);
    }
}