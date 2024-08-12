using MatchingApp.Data;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchingApp.Services.Matching;

public class MatchingService : IMatchingService
{
    private readonly ApplicationDbContext _dbContext;

    public MatchingService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetUsersDto> GetUsers(Filters filters, string userId)
    {
        return new GetUsersDto()
        {
            TopUsers = await _dbContext.Matches.Where(x => x.LikedId == userId)
                .OrderBy(x => Guid.NewGuid()).Take(100).Select(x => x.Liker).ToListAsync(),
            Users = await _dbContext.Users.ToListAsync()
        };
    }

    public Task Match(string userId, string loggedUserId, bool like)
    {
        return like ? Like(userId, loggedUserId) : Unlike(userId, loggedUserId);
    }

    private async Task Like(string userId, string loggedUserId)
    {
        var isLiked = await _dbContext.Matches
            .Where(match => match.LikedId == loggedUserId && match.LikerId == userId && match.IsMutual)
            .FirstOrDefaultAsync();

        if (isLiked != null)
        {
            if (isLiked.IsMutual)
            {
                throw new Exception("Already liked");
            }

            isLiked.IsMutual = true;
        }
        else
        {
            var match = new Match
            {
                LikerId = loggedUserId,
                LikedId = userId,
                IsMutual = false,
                LikedAt = DateTime.UtcNow
            };

            await _dbContext.Matches.AddAsync(match);
        }

        await _dbContext.SaveChangesAsync();
    }

    private async Task Unlike(string userId, string loggedUserId)
    {
        var isLiked = await _dbContext.Matches
            .Where(match => match.LikedId == loggedUserId && match.LikerId == userId && match.IsMutual)
            .FirstOrDefaultAsync();

        if (isLiked is null)
        {
            throw new Exception($"There is no like from the user with id: {userId}");
        }

        _dbContext.Matches.Remove(isLiked);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task Message(string userId, string loggedUserId, string content)
    {
        var isMatched = await _dbContext.Matches
            .Where(match => match.IsMutual &&
                            ((match.LikerId == userId && match.LikedId == loggedUserId)
                             || (match.LikedId == userId && match.LikerId == loggedUserId)))
            .FirstOrDefaultAsync();

        if (isMatched is null)
        {
            throw new Exception($"You are not matched with user with id: {userId}");
        }

        var message = new Message
        {
            SenderId = loggedUserId,
            ReceiverId = userId,
            Content = content,
            SentAt = DateTime.UtcNow
        };
        
        await _dbContext.Messages.AddAsync(message);
    }
}