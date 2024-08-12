using MatchingApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

public class Match
{
    [Key]
    public int Id { get; set; }

    public string LikerId { get; set; }  
    public User Liker { get; set; }

    public string LikedId { get; set; }  
    public User Liked { get; set; }

    public bool IsMutual { get; set; }
    public DateTime MatchDate { get; set; }
}
