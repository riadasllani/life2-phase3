using MatchingApp.Models.Entities;

namespace MatchingApp.Models.Dtos;

public class GetUsersDto
{
    public List<User> TopUsers { get; set; }
    public List<User> Users { get; set; }
}