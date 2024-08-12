using MatchingApp.Models.Dtos;

namespace MatchingApp.Services.Matching;

public interface IMatchingService
{

    Task<GetUsersDto> GetUsers(Filters filters, string userId);
    Task Match(string userId, string loggedUserId, bool like);
    Task Message(string userId, string loggedUserId, string content);
}