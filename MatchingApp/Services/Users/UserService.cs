using MatchingApp.Data;
using MatchingApp.Enums;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchingApp.Services.Users;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> HighestCredits(int count)
    {
        return await _dbContext.Users.Where(user => user.Active)
            .OrderByDescending(user => user.Credits)
            .Take(count)
            .ToListAsync();
    }

    public async Task<Dictionary<Gender, double>> AverageCreditsByGender()
    {
        return await _dbContext.Users.GroupBy(user => user.Gender)
            .ToDictionaryAsync(x => x.Key, x => x.Average(user => user.Credits));
    }

    public async Task<YoungestOldestUsersDto> YoungestOldestUsers()
    {
        var youngestOldestUsers = new YoungestOldestUsersDto
        {
            Youngest = await _dbContext.Users
                .Where(x => x.Age == _dbContext.Users.Select(x => x.Age).Min())
                .ToListAsync(),
            Oldest = await _dbContext.Users
                .Where(x => x.Age == _dbContext.Users.Select(x => x.Age).Max())
                .ToListAsync()
        };

        return youngestOldestUsers;
    }

    public Dictionary<string, int> TotalCreditsByAgeGroup()
    {
        IEnumerable<(int start, int end)> groups = Enumerable.Range(0, 7).Select(x => (x * 15, (x + 1) * 15));

        return groups.ToDictionary(tuple => $"{tuple.start}-{tuple.end}", tuple => _dbContext.Users
            .Where(x => x.Age >= tuple.start && x.Age < tuple.end)
            .Sum(x => x.Credits));
    }
}