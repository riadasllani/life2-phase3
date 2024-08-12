using MatchingApp.Enums;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;

namespace MatchingApp.Services.Users;

public interface IUserService
{
    Task<List<User>> HighestCredits(int count);
    Task<Dictionary<Gender, double>> AverageCreditsByGender();
    Task<YoungestOldestUsersDto> YoungestOldestUsers();
    Dictionary<string, int> TotalCreditsByAgeGroup();
}