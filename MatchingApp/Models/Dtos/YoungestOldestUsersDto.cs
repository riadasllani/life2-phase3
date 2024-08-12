using MatchingApp.Models.Entities;

namespace MatchingApp.Models.Dtos;

public class YoungestOldestUsersDto
{
    public List<User> Youngest { get; set; }
    public List<User> Oldest { get; set; }
}